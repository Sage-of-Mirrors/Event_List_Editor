using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WindViewer;
using WindViewer.Editor;
using OpenTK;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    class DatExporter
    {
        int eventIndex = 0;
        int actorIndex = 0;
        int actionIndex = 0;
        int propIndex = 0;

        int streamPosition = 0;

        int stringOffset;

        int genericCount = 0; //Using this for action indexes right now

        List<float> floats = new List<float>();
        List<int> ints = new List<int>();
        List<string> strings = new List<string>();

        public void export(List<eventClass> eventList, string fileName)
        {
            BinaryWriter bw = new BinaryWriter(File.Open(fileName, FileMode.Create));

            byte[] emptyHeader = new byte[64];

            FSHelpers.WriteArray(bw, emptyHeader);

            streamPosition = (int)bw.BaseStream.Position;

            bw.BaseStream.Position = 0;

            FSHelpers.Write32(bw, streamPosition);

            FSHelpers.Write32(bw, eventList.Count);

            bw.BaseStream.Position = streamPosition;

            foreach (eventClass evClass in eventList)
            {
                evClass.save(bw, eventIndex);

                streamPosition = (int)bw.BaseStream.Position;

                bw.BaseStream.Position -= 132;

                foreach (actorClass actClass in evClass.actors)
                {
                    FSHelpers.Write32(bw, actorIndex);

                    actorIndex += 1;
                }

                eventIndex += 1;

                bw.BaseStream.Position = streamPosition;
            }

            streamPosition = (int)bw.BaseStream.Position;

            bw.BaseStream.Position = 8;

            FSHelpers.Write32(bw, streamPosition);

            bw.BaseStream.Position = streamPosition;

            actorIndex = 0;

            foreach (eventClass evClass in eventList)
            {
                foreach (actorClass actClass in evClass.actors)
                {
                    if (evClass == eventList[eventList.Count - 1])
                    {
                    }

                    actClass.save(bw, actorIndex, actionIndex);

                    actorIndex += 1;

                    actionIndex += actClass.actions.Count;
                }
            }

            streamPosition = (int)bw.BaseStream.Position;

            bw.BaseStream.Position = 12;

            FSHelpers.Write32(bw, actorIndex);

            FSHelpers.Write32(bw, streamPosition);

            FSHelpers.Write32(bw, actionIndex);

            bw.BaseStream.Position = streamPosition;

            actionIndex = 0;

            foreach (eventClass evClass in eventList)
            {
                foreach (actorClass actClass in evClass.actors)
                {
                    foreach (actionClass actionClass in actClass.actions)
                    {
                        if (actionClass.properties.Count == 0)
                        {
                            actionClass.propertyIndex = -1;
                        }

                        else if (actionClass.properties.Count != 0)
                        {
                            actionClass.propertyIndex = propIndex;
                        }

                        if (actionClass != actClass.actions[actClass.actions.Count - 1])
                        {
                            actionIndex += 1;

                            actionClass.save(bw, genericCount, actionIndex);

                            genericCount += 1;

                            propIndex += actionClass.properties.Count;
                        }

                        else
                        {
                            actionIndex += 1;

                            actionClass.save(bw, genericCount, -1);

                            genericCount += 1;

                            propIndex += actionClass.properties.Count;
                        }
                    }
                }
            }

            streamPosition = (int)bw.BaseStream.Position;

            bw.BaseStream.Position = 24;

            FSHelpers.Write32(bw, streamPosition);

            FSHelpers.Write32(bw, propIndex);

            bw.BaseStream.Position = streamPosition;

            propIndex = 0;

            genericCount = 0;

            foreach (eventClass evClass in eventList)
            {
                foreach (actorClass actClass in evClass.actors)
                {
                    foreach (actionClass actionClass in actClass.actions)
                    {
                        foreach (propertyClass propClass in actionClass.properties)
                        {
                            switch (propClass.dataType)
                            {
                                case 0:
                                    if (floats.Contains(Convert.ToSingle(propClass.propData)) == true)
                                    {
                                        propClass.dataIndex = floats.IndexOf(Convert.ToSingle(propClass.propData));
                                    }

                                    else
                                    {
                                        floats.Add(Convert.ToSingle(propClass.propData));

                                        propClass.dataIndex = floats.IndexOf(Convert.ToSingle(propClass.propData));
                                    }

                                    propClass.dataLength = 1;

                                    break;

                                case 1:
                                    propClass.dataIndex = floats.Count;

                                    string vectorIsolate = Convert.ToString(propClass.propData);

                                    vectorIsolate = vectorIsolate.Remove(0, 1);

                                    vectorIsolate = vectorIsolate.Remove(vectorIsolate.Length - 1, 1);

                                    vectorIsolate = Regex.Replace(vectorIsolate, " ", "");

                                    string[] vector = vectorIsolate.Split(',');

                                    foreach (string str in vector)
                                    {
                                        floats.Add(Convert.ToSingle(str));
                                    }

                                    propClass.dataLength = 1;

                                    break;

                                case 3:
                                    if (ints.Contains(Convert.ToInt32(propClass.propData)) == true)
                                    {
                                        propClass.dataIndex = ints.IndexOf(Convert.ToInt32(propClass.propData));
                                    }

                                    else
                                    {
                                        ints.Add(Convert.ToInt32(propClass.propData));

                                        propClass.dataIndex = ints.IndexOf(Convert.ToInt32(propClass.propData));
                                    }

                                    propClass.dataLength = 1;

                                    break;

                                case 4:
                                    strings.Add(propClass.propData);
                                    
                                    if (propClass.propData.Length < 8)
                                    {
                                        propClass.dataIndex = stringOffset;

                                        stringOffset += 8;

                                        propClass.dataLength = 8;

                                        break;
                                    }
                                    
                                    if (propClass.propData.Length >= 8)
                                    {
                                        if (propClass.propData.Length >= 16)
                                        {
                                            propClass.dataIndex = stringOffset;

                                            stringOffset += 24;

                                            propClass.dataLength = 24;

                                            break;
                                        }

                                        if (propClass.propData.Length >= 24)
                                        {
                                            propClass.dataIndex = stringOffset;

                                            stringOffset += 32;

                                            propClass.dataLength = 32;

                                            break;
                                        }

                                        else
                                        {
                                            propClass.dataIndex = stringOffset;

                                            stringOffset += 16;

                                            propClass.dataLength = 16;

                                            break;
                                        }
                                    }

                                    break;
                            }

                            genericCount += 1;

                            if (propClass != actionClass.properties[actionClass.properties.Count - 1])
                            {
                                propClass.save(bw, propIndex, genericCount);
                            }

                            else
                            {
                                propClass.save(bw, propIndex, -1);
                            }

                            propIndex += 1;
                        }
                    }
                }
            }

            streamPosition = (int)bw.BaseStream.Position;

            bw.BaseStream.Position = 32;

            FSHelpers.Write32(bw, streamPosition);
            FSHelpers.Write32(bw, floats.Count);

            bw.BaseStream.Position = streamPosition;

            foreach (float fl in floats)
            {
                FSHelpers.WriteFloat(bw, fl);
            }

            streamPosition = (int)bw.BaseStream.Position;

            bw.BaseStream.Position = 40;

            FSHelpers.Write32(bw, streamPosition);
            FSHelpers.Write32(bw, ints.Count);

            bw.BaseStream.Position = streamPosition;

            foreach (int integ in ints)
            {
                FSHelpers.Write32(bw, integ);
            }

            streamPosition = (int)bw.BaseStream.Position;

            bw.BaseStream.Position = 48;

            FSHelpers.Write32(bw, streamPosition);

            bw.BaseStream.Position = streamPosition;

            foreach (string str in strings)
            {
                if (str.Length < 8)
                {
                    FSHelpers.WriteString(bw, str, 8);
                }

                if (str.Length >= 8)
                {
                    if (str.Length >= 16)
                    {
                        FSHelpers.WriteString(bw, str, 24);

                        continue;
                    }

                    if (str.Length >= 24)
                    {
                        FSHelpers.WriteString(bw, str, 32);

                        continue;
                    }

                    else
                    {
                        FSHelpers.WriteString(bw, str, 16);

                        continue;
                    }
                }
            }

            int stringBankSize = (int)bw.BaseStream.Position - streamPosition;

            bw.BaseStream.Position = 52;

            FSHelpers.Write32(bw, stringBankSize);

            bw.Flush();

            bw.Close();
        }
    }
}

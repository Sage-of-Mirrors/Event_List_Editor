using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WindViewer;
using WindViewer.Editor;

namespace WindowsFormsApplication1
{
    public class eventClass
    {
        public string eventName;
        public int eventIndex;
        public int unknown1; //0 or 1
        public int eventPriority;
        public int[] actorIndexes = new int[20];
        public int actorCount;
        public int[] flags = new int[5];
        public byte eventSound;

        //The rest of these fields just seem to be used by the engine at runtime.
        //I'm not going to map them to anything since they're all typically 0.
        //Just remember to add the extra 27 bytes to the end of an event when
        //it's being written to file.
        public byte unknownByte1; //Always 0
        public byte unknownByte2; //Always 0
        public byte unknownByte3; //Always 0
        public int unknown6; //Always 0
        public int unknown7; //Always 0
        public int unknown8; //Always 0
        public int eventState; //Always 0-initialized
        public int unknown9; //Always 0
        public int unknown10; //Always 0

        public List<actorClass> actors = new List<actorClass>();

        public void load(byte[] data, int offset)
        {
            eventName = Helpers.ReadString(data, offset);
            eventIndex = (int)Helpers.Read32(data, offset + 32);
            unknown1 = (int)Helpers.Read32(data, offset + 36);
            eventPriority = (int)Helpers.Read32(data, offset + 40);

            for (int i = 0; i < 20; i++)
            {
                int tempInt = (int)Helpers.Read32(data, offset + 44 + (i * 4));

                actorIndexes[i] = tempInt;
            }

            actorCount = (int)Helpers.Read32(data, offset + 124);

            for (int i = 0; i < 5; i++)
            {
                int tempInt = (int)Helpers.Read32(data, offset + 128 + (i * 4));

                flags[i] = tempInt;
            }

            eventSound = Helpers.Read8(data, offset + 148);

            if (eventSound > 1)
            {
                Console.Write("Event sound was " + eventSound + Environment.NewLine);
            }

            return;
        }

        public void save(BinaryWriter bw, int index)
        {
            FSHelpers.WriteString(bw, eventName, 32);

            FSHelpers.Write32(bw, index);
            FSHelpers.Write32(bw, unknown1);
            FSHelpers.Write32(bw, eventPriority);

            byte[] nullIndexArray = new byte[80];

            for (int i = 0; i < 80; i++)
            {
                nullIndexArray[i] = 255;
            }

            FSHelpers.WriteArray(bw, nullIndexArray);
            FSHelpers.Write32(bw, actors.Count);
            FSHelpers.Write32(bw, flags[0]);
            FSHelpers.Write32(bw, flags[1]);
            FSHelpers.Write32(bw, flags[2]);
            FSHelpers.Write32(bw, flags[3]);
            FSHelpers.Write32(bw, flags[4]);
            FSHelpers.Write8(bw, eventSound);

            byte[] ramZeros = new byte[27];

            FSHelpers.WriteArray(bw, ramZeros);
        }
    }

    public class actorClass
    {
        //0x50/80 bytes long
        /*0x00*/ public string name; //0x20/32 byte-space
        /*0x20*/ public int staffIdentifer; //Don't know what this is, J.H. wasn't sure either
        /*0x24*/ public int curActorIndex; //Index of this actor
        /*0x28*/ public int unknown1; //Changes by actor, generally increasing as it goes
        /*0x2C*/ public int staffType; //0 is a special case, 02 is another special case...
        /*0x30*/ public int initialActionIndex; //First action the actor performs

        //These fields are the same as in events. They are initialized to 0,
        //and seem to be used by the engine at runtime. Not gonna map these.
        /*0x34*/ public int unknown2; //Always 0?
        /*0x38*/ public int currentActionIndex; //Probably used while the event is running
        /*0x3C*/ public int actIndex; //Apparently stores the string length of the current action?
        /*0x40*/ public int unknown3; //Always 0?
        /*0x44*/ public byte unknownb1; //Always 0?
        /*0x45*/ public byte unknownb2; //Always 0?
        /*0x46*/ public byte isAdvance; //Engine might set this when the actor is moving onto its next action
        /*0x47*/ public byte unknownb3; //Always 0?
        /*0x48*/ public int unknown4; //Always 0?
        /*0x4C*/ public int unknown5; //Always 0?

        public bool isLastAction = false;

        public List<actionClass> actions = new List<actionClass>();

        public void load(byte[] data, int offset, int actionsOffset, int propertyOffset)
        {
            name = Helpers.ReadString(data, offset);
            staffIdentifer = (int)Helpers.Read32(data, offset + 32);
            curActorIndex = (int)Helpers.Read32(data, offset + 36);
            unknown1 = (int)Helpers.Read32(data, offset + 40);
            staffType = (int)Helpers.Read32(data, offset + 44);
            initialActionIndex = (int)Helpers.Read32(data, offset + 48);

            int thisActionIndex = initialActionIndex;

            while (isLastAction == false)
            {
                actionClass action = new actionClass();

                int localOffset = actionsOffset + (thisActionIndex * 80);

                action.load(data, localOffset, propertyOffset);

                if (action.nextActionIndex == -1)
                {
                    isLastAction = true;
                }

                else if (action.nextActionIndex != -1)
                {
                    thisActionIndex = action.nextActionIndex;
                }

                actions.Add(action);
            }
        }

        public void save(BinaryWriter bw, int thisIndex, int firstActionIndex)
        {
            FSHelpers.WriteString(bw, name, 32);
            FSHelpers.Write32(bw, staffIdentifer);
            FSHelpers.Write32(bw, thisIndex);
            FSHelpers.Write32(bw, unknown1);
            FSHelpers.Write32(bw, staffType);
            FSHelpers.Write32(bw, firstActionIndex);

            FSHelpers.WriteArray(bw, new byte[28]);
        }
    }

    public class actionClass
    {
        //0x50/80 bytes long
        /*0x00*/ public string name; //0x20/32 byte-space...
        /*0x20*/ public int uniqueID; //For when actions share the same name
        /*0x24*/ public int curActionIndex; //Index of this action
        /*0x28*/ public int[] unknownAry1 = new int[3];
        /*0x34*/ public int unknown5; //Different in each action. Not always set
        /*0x38*/ public int propertyIndex; //Index of a property
        /*0x3C*/ public int nextActionIndex; //Next action to perform. If it's 0xFFFFFFFF/-1 dec, then there is no next action

        //Same deal as above here. Always 0, used at runtime
        /*0x40*/ public int unknown6; //Always 0?
        /*0x44*/ public int unknown7; //Always 0?
        /*0x48*/ public int unknown8; //Always 0?
        /*0x4C*/ public int unknown9; //Always 0?

        public bool isLastProperty = false;

        public List<propertyClass> properties = new List<propertyClass>();

        public void load(byte[] data, int offset, int propertyOffset)
        {
            name = Helpers.ReadString(data, offset);
            uniqueID = (int)Helpers.Read32(data, offset + 32);
            curActionIndex = (int)Helpers.Read32(data, offset + 36);

            for (int i = 0; i < 3; i++)
            {
                int tempInt = (int)Helpers.Read32(data, offset + 40 + (i * 4));

                unknownAry1[i] = tempInt;
            }

            unknown5 = (int)Helpers.Read32(data, offset + 52);
            propertyIndex = (int)Helpers.Read32(data, offset + 56);

            if (propertyIndex == -1)
            {
                isLastProperty = true;
            }

            int thisPropertyIndex = propertyIndex;

            while (isLastProperty == false)
            {
                propertyClass prop = new propertyClass();

                int localOffset = propertyOffset + (thisPropertyIndex * 64);

                prop.load(data, localOffset);

                properties.Add(prop);

                if (prop.nextPropertyIndex == -1)
                {
                    isLastProperty = true;
                }

                else if (prop.nextPropertyIndex != -1)
                {
                    thisPropertyIndex = prop.nextPropertyIndex;
                }
            }

            nextActionIndex = (int)Helpers.Read32(data, offset + 60);
        }

        public void save(BinaryWriter bw, int thisIndex, int nextIndex)
        {
            FSHelpers.WriteString(bw, name, 32);
            FSHelpers.Write32(bw, uniqueID);
            FSHelpers.Write32(bw, thisIndex);
            FSHelpers.Write32(bw, unknownAry1[0]);
            FSHelpers.Write32(bw, unknownAry1[1]);
            FSHelpers.Write32(bw, unknownAry1[2]);
            FSHelpers.Write32(bw, unknown5);
            FSHelpers.Write32(bw, propertyIndex);
            FSHelpers.Write32(bw, nextIndex);
            FSHelpers.WriteArray(bw, new byte[16]);
        }
    }

    public class propertyClass
    {
        //0x40/64 bytes long
        /*0x00*/ public string name; //0x20/32 byte-space!
        /*0x20*/ public int curPropertyIndex; //Index of this property
        /*0x24*/ public int dataType; //01 means single float; 02 means vector3; 03 means int; 04 means string
        /*0x28*/ public int dataIndex; //Index of data in respective bank
        /*0x2C*/ public int dataLength; //Length of data
        /*0x30*/ public int nextPropertyIndex; //Next property? If 0xFFFFFFFF/4294967295 dec, then there is no next
        /*0x34*/ public int unknown1; //Always 0?
        /*0x38*/ public int unknown2; //Always 0?
        /*0x3C*/ public int unknown3; //Always 0?

        public dynamic propData;

        public void load(byte[] data, int offset)
        {
            name = Helpers.ReadString(data, offset);
            curPropertyIndex = (int)Helpers.Read32(data, offset + 32);
            dataType = (int)Helpers.Read32(data, offset + 36);
            dataIndex = (int)Helpers.Read32(data, offset + 40);
            dataLength = (int)Helpers.Read32(data, offset + 44);
            nextPropertyIndex = (int)Helpers.Read32(data, offset + 48);
        }

        public void save(BinaryWriter bw, int thisIndex, int nextIndex)
        {
            FSHelpers.WriteString(bw, name, 32);
            FSHelpers.Write32(bw, thisIndex);
            FSHelpers.Write32(bw, dataType);
            FSHelpers.Write32(bw, dataIndex);
            FSHelpers.Write32(bw, dataLength);
            FSHelpers.Write32(bw, nextIndex);
            FSHelpers.WriteArray(bw, new byte[12]);
        }
    }

    class DatParser
    {
        //Let's declare our class lists
        public List<eventClass> eventClassList = new List<eventClass>();

        //Now our value lists
        private List<float> floatList = new List<float>();
        private List<int> intList = new List<int>();
        private byte[] stringData;
        //private List<string> stringList = new List<string>();

        //Finally, some variables
        public int eventOffset, eventCount, actorOffset, actorCount, actionOffset, actionCount,
            propertyOffset, propertyCount, floatOffset, floatCount, intOffset, intCount,
            stringOffset, stringCount, offset;

        public List<eventClass> parse(byte[] data)
        {
            //We need these in order to load the data
            eventOffset = (int)Helpers.Read32(data, 0);
            eventCount = (int)Helpers.Read32(data, 4);
            actorOffset = (int)Helpers.Read32(data, 8);
            actorCount = (int)Helpers.Read32(data, 12);
            actionOffset = (int)Helpers.Read32(data, 16);
            actionCount = (int)Helpers.Read32(data, 20);
            propertyOffset = (int)Helpers.Read32(data, 24);
            propertyCount = (int)Helpers.Read32(data, 28);
            floatOffset = (int)Helpers.Read32(data, 32);
            floatCount = (int)Helpers.Read32(data, 36);
            intOffset = (int)Helpers.Read32(data, 40);
            intCount = (int)Helpers.Read32(data, 44);
            stringOffset = (int)Helpers.Read32(data, 48);
            stringCount = (int)Helpers.Read32(data, 52);

            stringData = new byte[stringCount];

            offset = eventOffset;

            for (int i = 0; i < eventCount; i++)
            {
                eventClass ev = new eventClass();

                ev.load(data, offset);

                offset += 176;

                eventClassList.Add(ev);
            }

            offset = actorOffset;

            foreach (eventClass evClass in eventClassList)
            {
                for (int i = 0; i < evClass.actorCount; i++)
                {
                    actorClass act = new actorClass();

                    //We're not going to load a list of actors. We're just going to
                    //grab the actors that we need by doing some math. Fun!

                    int localOffset = offset + (evClass.actorIndexes[i] * 80);

                    act.load(data, localOffset, actionOffset, propertyOffset);

                    evClass.actors.Add(act);
                }
            }

            offset = floatOffset;

            for (int i = 0; i < floatCount; i++)
            {
                float tempFloat = Helpers.ConvertIEEE754Float(Helpers.Read32(data, offset));

                floatList.Add(tempFloat);

                offset += 4;
            }

            offset = intOffset;

            for (int i = 0; i < intCount; i++)
            {
                int tempInt = (int)Helpers.Read32(data, offset);

                intList.Add(tempInt);

                offset += 4;
            }

            offset = stringOffset;

            //The string data is referenced in the property data by offset, so...
            //We have to get the string data by itself in binary form.

            Array.Copy(data, offset, stringData, 0, data.Length - offset);

            /*for (int i = 0; i < stringCount; i += 8)
            {
                    string tempString = Helpers.ReadString(data, offset);

                    stringList.Add(tempString);

                    offset += tempString.Length;

                    //If the length of the string is less than 8, we have to
                    //add a bit more to the offset to compensate.

                    if (tempString.Length < 8)
                    {
                        offset += 8 - tempString.Length;

                        continue;
                    }

                    //Likewise, if the string length is GREATER than 8,
                    //We have to adjust the offset.

                    //The file format apparently likes to pad to multiples of 8.

                    else if (tempString.Length >= 8)
                    {
                        if (tempString.Length >= 16)
                        {
                            offset += 24 - tempString.Length;

                            i += 16;

                            continue;
                        }

                        else if (tempString.Length >= 24)
                        {
                            offset += 32 - tempString.Length;

                            i += 24;

                            continue;
                        }

                        offset += 16 - tempString.Length;

                        i += 8;

                        continue;
                    }
                
            }*/

            return eventClassList;
        }

        public List<float> getFloatList()
        {
            List<float> floatListPub = new List<float>(floatList);

            return floatListPub;
        }

        public List<int> getIntList()
        {
            List<int> intListPub = new List<int>(intList);

            return intListPub;
        }

        public byte[] getStringData()
        {
            return stringData;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindViewer;
using OpenTK;

namespace WindowsFormsApplication1
{
    public partial class MainUI : Form
    {
        #region Variables

        //Raw binary data from the file
        public byte[] data;

        //The list of events created from the file
        public List<eventClass> eventList;

        //The float list from the file
        public List<float> floatDataList;

        //The integer list from the file
        public List<int> intDataList;

        //The string bank from the file. See loadPropertyData()
        public byte[] stringData;

        //Bool to check if a file has been loaded
        public bool isLoaded = false;

        //Bool used in moving nodes up/down to check if the node
        //is the last of its siblings
        bool isLastNode = false;

        //Node indexes for easy access. Set by getSelectedNodes()
        public int evtNode = 0;
        public int actNode = 0;
        public int acnNode = 0;
        public int proNode = 0;

        #endregion

        #region Element Adding/Deleting

        //Events
        private void addEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isLoaded == true)
            {
                eventClass newEvent = new eventClass();

                newEvent.eventName = "default";
                newEvent.eventIndex = 0;
                newEvent.unknown1 = 0;
                newEvent.eventPriority = 0;

                newEvent.actors = new List<actorClass>();

                newEvent.flags = new int[5] { -1, -1, -1, -1, -1 };

                newEvent.eventSound = 0;

                eventList.Add(newEvent);

                TreeNode newEventNode = new TreeNode();

                newEventNode.Text = newEvent.eventName;

                newEventNode.Tag = 0;

                treeView1.BeginUpdate();

                treeView1.Nodes.Add(newEventNode);

                treeView1.EndUpdate();

                treeView1.SelectedNode = treeView1.Nodes[treeView1.Nodes.Count - 1];
            }
        }

        private void deleteEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eventList.RemoveAt(evtNode);

            controlPanel.Controls.Clear();

            treeView1.SelectedNode.Remove();
        }

        //Actors
        private void addActorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actorClass newActor = new actorClass();

            newActor.name = "default";
            newActor.staffIdentifer = 0;
            newActor.unknown1 = 0;
            newActor.staffType = 0;

            newActor.actions = new List<actionClass>();

            eventList[evtNode].actors.Add(newActor);

            TreeNode newActorNode = new TreeNode();

            newActorNode.Text = newActor.name;

            newActorNode.Tag = 1;

            treeView1.BeginUpdate();

            treeView1.SelectedNode.Nodes.Add(newActorNode);

            treeView1.EndUpdate();
        }

        private void deleteActorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eventList[evtNode].actors.RemoveAt(actNode);

            controlPanel.Controls.Clear();

            treeView1.SelectedNode.Remove();
        }

        //Actions
        private void addActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actionClass newAction = new actionClass();

            newAction.name = "default";
            newAction.uniqueID = 0;
            newAction.unknownAry1 = new int[3] { -1, -1, -1 };
            newAction.unknown5 = 0;

            eventList[evtNode].actors[actNode].actions.Add(newAction);

            TreeNode newActionNode = new TreeNode();

            newActionNode.Text = newAction.name;

            newActionNode.Tag = 2;

            treeView1.Nodes[evtNode].Nodes[actNode].Nodes.Add(newActionNode);
        }

        private void deleteActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eventList[evtNode].actors[actNode].actions.RemoveAt(acnNode);

            treeView1.SelectedNode.Remove();
        }

        //Properties
        private void addPropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            propertyClass newProp = new propertyClass();

            newProp.name = "default";
            newProp.dataType = 0;
            newProp.dataIndex = 0;
            newProp.propData = 0;

            eventList[evtNode].actors[actNode].actions[acnNode].properties.Add(newProp);

            TreeNode newPropNode = new TreeNode();

            newPropNode.Text = "default";

            newPropNode.Tag = 3;

            treeView1.Nodes[evtNode].Nodes[actNode].Nodes[acnNode].Nodes.Add(newPropNode);
        }

        private void deletePropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eventList[evtNode].actors[actNode].actions[acnNode].properties.RemoveAt(proNode);

            treeView1.SelectedNode.Remove();
        }

        #endregion

        #region Element updating

        //Events
        public void updateEventData(string name, int priority, int flag1, int flag2, int flag3, int flag4, int flag5, int sound)
        {
            //Called by EventControl to update the currently selected event's data with the values from the
            //control itself.
            eventList[evtNode].eventName = name;
            eventList[evtNode].eventPriority = priority;
            eventList[evtNode].flags[0] = flag1;
            eventList[evtNode].flags[1] = flag2;
            eventList[evtNode].flags[2] = flag3;
            eventList[evtNode].flags[3] = flag4;
            eventList[evtNode].flags[4] = flag5;
            eventList[evtNode].eventSound = (byte)sound;

            //Update the node's name in the TreeView.
            treeView1.Nodes[evtNode].Text = eventList[evtNode].eventName;
        }

        //Actors
        public void updateActorData(string name, int staffID, int unknown1, int staffType)
        {
            //Called by ActorControl to update the currently selected event's data with the values from the
            //control itself.
            eventList[evtNode].actors[actNode].name = name;
            eventList[evtNode].actors[actNode].staffIdentifer = staffID;
            eventList[evtNode].actors[actNode].unknown1 = unknown1;
            eventList[evtNode].actors[actNode].staffType = staffType;

            //Update the node's name in the TreeView.
            treeView1.Nodes[evtNode].Nodes[actNode].Text = eventList[evtNode].actors[actNode].name;
        }

        //Actions
        public void updateActionData(string name, int dupID, int array1, int array2, int array3, int unknown5)
        {
            //Called by ActionControl to update the currently selected event's data with the values from the
            //control itself.
            eventList[evtNode].actors[actNode].actions[acnNode].name = name;
            eventList[evtNode].actors[actNode].actions[acnNode].uniqueID = dupID;
            eventList[evtNode].actors[actNode].actions[acnNode].unknownAry1[0] = array1;
            eventList[evtNode].actors[actNode].actions[acnNode].unknownAry1[1] = array2;
            eventList[evtNode].actors[actNode].actions[acnNode].unknownAry1[2] = array3;
            eventList[evtNode].actors[actNode].actions[acnNode].unknown5 = unknown5;

            //Update the node's name in the TreeView.
            treeView1.Nodes[evtNode].Nodes[actNode].Nodes[acnNode].Text = eventList[evtNode].actors[actNode].actions[acnNode].name;
        }

        //Properties
        public void updatePropData(string name, int type, dynamic data)
        {
            //Called by PropertyControl to update the currently selected event's data with the values from the
            //control itself.
            eventList[evtNode].actors[actNode].actions[acnNode].properties[proNode].name = name;
            eventList[evtNode].actors[actNode].actions[acnNode].properties[proNode].dataType = type;
            eventList[evtNode].actors[actNode].actions[acnNode].properties[proNode].propData = data;

            //Update the node's name in the TreeView.
            treeView1.Nodes[evtNode].Nodes[actNode].Nodes[acnNode].Nodes[proNode].Text =
                eventList[evtNode].actors[actNode].actions[acnNode].properties[proNode].name;
        }

        #endregion

        #region Element Up/Downs

        //Events (See moveEventUp() for a note)
        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (eventList[evtNode] != eventList[0]) //We can't move the first event up
            {
                moveEventUp();
            }
        }

        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (eventList[evtNode] != eventList[eventList.Count - 1]) //We can't move the last event down
            {
                moveEventDown();

                treeView1.SelectedNode = treeView1.Nodes[evtNode + 1];
            }
        }

        private void moveEventUp()
        {
            eventClass tempEvClass = eventList[evtNode]; //Put the selected event in a buffer
            eventList.RemoveAt(evtNode); //Remove the selected event from the list
            eventList.Insert(evtNode - 1, tempEvClass); //Re-insert the event at its original index - 1

            treeView1.BeginUpdate(); //Treeview no painting! Treeview no painting!

            if (treeView1.Nodes[evtNode] == treeView1.Nodes[treeView1.Nodes.Count - 1])
            {
                isLastNode = true;

                //A weird bug causes the selected node index to decrease by 1 when the node is deleted in the statement above
                //if it's the last node in the tree. With the default - 1 in the re-add statement, that makes the re-added
                //Node have an index that's one too low. Node 72 ends up being inserted at index 70, for example.
                //So, we have a check to see if the removed node is the last one. If it is, we do something slightly
                //different when we re-add the node at a different point in the tree - rely on the bug entirely
                //for the change in the index, and - 1 from the index in all other cases. This applies to all of the
                //moveUp functions.
            }

            TreeNode tempEvNode = treeView1.Nodes[evtNode]; //Selected node to the buffer
            treeView1.Nodes.RemoveAt(evtNode); //Remove the selected node

            if (isLastNode == true)
            {
                treeView1.Nodes.Insert(evtNode, tempEvNode); //Re-insert the node above where it was

                treeView1.SelectedNode = treeView1.Nodes[evtNode];
            }

            else
            {
                treeView1.Nodes.Insert(evtNode - 1, tempEvNode); //Re-insert the node above where it was

                treeView1.SelectedNode = treeView1.Nodes[evtNode - 1];
            }

            treeView1.EndUpdate(); //Treeview can paint again

            isLastNode = false;
        }

        private void moveEventDown()
        {
            eventClass tempEvClass = eventList[evtNode]; //Put the selected event in a buffer
            eventList.RemoveAt(evtNode); //Remove the selected event from the list
            eventList.Insert(evtNode + 1, tempEvClass); //Re-insert the event at its original index + 1

            treeView1.BeginUpdate(); //TreeView no painting! Treeview no painting!

            TreeNode tempEvNode = treeView1.Nodes[evtNode]; //Selected node to the buffer
            treeView1.Nodes.RemoveAt(evtNode); //Remove the selected node
            treeView1.Nodes.Insert(evtNode + 1, tempEvNode); //Re-insert the node below where it was

            treeView1.EndUpdate(); //TreeView can paint again
        }

        //Actors
        private void moveUpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (eventList[evtNode].actors[actNode] != eventList[evtNode].actors[0]) //Check if we've selected the first actor
            {
                moveActorUp();
            }
        }

        private void moveDownToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (eventList[evtNode].actors[actNode] != eventList[evtNode].actors[eventList[evtNode].actors.Count - 1]) //Check if we've selected the last actor
            {
                moveActorDown();

                treeView1.SelectedNode = treeView1.Nodes[evtNode].Nodes[actNode + 1];
            }
        }

        private void moveActorUp()
        {
            actorClass tempActClass = eventList[evtNode].actors[actNode]; //Put the actor in a buffer
            eventList[evtNode].actors.RemoveAt(actNode); //Remove original actor
            eventList[evtNode].actors.Insert(actNode - 1, tempActClass); //Insert buffer above original actor

            treeView1.BeginUpdate(); //TreeView can't paint

            if (treeView1.Nodes[evtNode].Nodes[actNode] == treeView1.Nodes[evtNode].Nodes[treeView1.Nodes[evtNode].Nodes.Count - 1])
            {
                isLastNode = true;
            }

            TreeNode tempActNode = treeView1.Nodes[evtNode].Nodes[actNode]; //Put selected node in a buffer
            treeView1.Nodes[evtNode].Nodes.RemoveAt(actNode); //Remove original node

            if (isLastNode == true)
            {
                treeView1.Nodes[evtNode].Nodes.Insert(actNode, tempActNode); //Re-insert the node above where it was

                treeView1.SelectedNode = treeView1.Nodes[evtNode].Nodes[actNode];
            }

            else
            {
                treeView1.Nodes[evtNode].Nodes.Insert(actNode - 1, tempActNode); //Re-insert the node above where it was

                treeView1.SelectedNode = treeView1.Nodes[evtNode].Nodes[actNode - 1];
            }

            treeView1.EndUpdate(); //TreeView can paint

            isLastNode = false;
        }

        private void moveActorDown()
        {
            actorClass tempActClass = eventList[evtNode].actors[actNode]; //Put the actor in a buffer
            eventList[evtNode].actors.RemoveAt(actNode); //Remove original actor
            eventList[evtNode].actors.Insert(actNode + 1, tempActClass); //Insert buffer below original actor

            treeView1.BeginUpdate(); //TreeView can't paint

            TreeNode tempActNode = treeView1.Nodes[evtNode].Nodes[actNode]; //Put selected node in a buffer
            treeView1.Nodes[evtNode].Nodes.RemoveAt(actNode); //Remove original node
            treeView1.Nodes[evtNode].Nodes.Insert(actNode + 1, tempActNode); //Insert buffer below original node

            treeView1.EndUpdate(); //TreeView can paint
        }

        //Actions
        private void moveUpToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (eventList[evtNode].actors[actNode].actions[acnNode] != eventList[evtNode].actors[actNode].actions[0])
            {
                moveActionUp();
            }
        }

        private void moveDownToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (eventList[evtNode].actors[actNode].actions[acnNode] != 
                    eventList[evtNode].actors[actNode].actions[eventList[evtNode].actors[actNode].actions.Count -1])
            {
                moveActionDown();

                treeView1.SelectedNode = treeView1.Nodes[evtNode].Nodes[actNode].Nodes[acnNode + 1];
            }
        }

        private void moveActionUp()
        {
            actionClass tempAcnClass = eventList[evtNode].actors[actNode].actions[acnNode]; //Put the action in a buffer
            eventList[evtNode].actors[actNode].actions.RemoveAt(acnNode); //Remove original action
            eventList[evtNode].actors[actNode].actions.Insert(acnNode - 1, tempAcnClass); //Insert buffer above original action

            treeView1.BeginUpdate(); //TreeView can't paint

            if (treeView1.Nodes[evtNode].Nodes[actNode].Nodes[acnNode] == treeView1.Nodes[evtNode].Nodes[actNode].Nodes[treeView1.Nodes[evtNode].Nodes[actNode].Nodes.Count - 1])
            {
                isLastNode = true;
            }

            TreeNode tempAcnNode = treeView1.Nodes[evtNode].Nodes[actNode].Nodes[acnNode]; //Put selected node in a buffer
            treeView1.Nodes[evtNode].Nodes[actNode].Nodes.RemoveAt(acnNode); //Remove original node

            if (isLastNode == true)
            {
                treeView1.Nodes[evtNode].Nodes[actNode].Nodes.Insert(acnNode, tempAcnNode); //Re-insert the node above where it was

                treeView1.SelectedNode = treeView1.Nodes[evtNode].Nodes[actNode].Nodes[acnNode];
            }

            else
            {
                treeView1.Nodes[evtNode].Nodes[actNode].Nodes.Insert(acnNode - 1, tempAcnNode); //Re-insert the node above where it was

                treeView1.SelectedNode = treeView1.Nodes[evtNode].Nodes[actNode].Nodes[acnNode - 1];
            }

            treeView1.EndUpdate(); //TreeView can paint

            isLastNode = false;
        }

        private void moveActionDown()
        {
            actionClass tempAcnClass = eventList[evtNode].actors[actNode].actions[acnNode]; //Put the action in a buffer
            eventList[evtNode].actors[actNode].actions.RemoveAt(acnNode); //Remove original action
            eventList[evtNode].actors[actNode].actions.Insert(acnNode + 1, tempAcnClass); //Insert buffer below original action

            treeView1.BeginUpdate(); //TreeView can't paint

            TreeNode tempAcnNode = treeView1.Nodes[evtNode].Nodes[actNode].Nodes[acnNode]; //Put selected node in a buffer
            treeView1.Nodes[evtNode].Nodes[actNode].Nodes.RemoveAt(acnNode); //Remove original node
            treeView1.Nodes[evtNode].Nodes[actNode].Nodes.Insert(acnNode + 1, tempAcnNode); //Insert buffer below original node

            treeView1.EndUpdate(); //TreeView can paint
        }

        //Properties
        private void moveUpToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (eventList[evtNode].actors[actNode].actions[acnNode].properties[proNode] != 
                    eventList[evtNode].actors[actNode].actions[acnNode].properties[0])
            {
                movePropUp();
            }
        }

        private void moveDownToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (eventList[evtNode].actors[actNode].actions[acnNode].properties[proNode] != eventList[evtNode].actors[actNode].actions[acnNode].properties[eventList[evtNode].actors[actNode].actions[acnNode].properties.Count - 1])
            {
                movePropDown();

                treeView1.SelectedNode = treeView1.Nodes[evtNode].Nodes[actNode].Nodes[acnNode].Nodes[proNode + 1];
            }
        }

        private void movePropUp()
        {
            propertyClass tempPropClass = eventList[evtNode].actors[actNode].actions[acnNode].properties[proNode]; //Put the action in a buffer
            eventList[evtNode].actors[actNode].actions[acnNode].properties.RemoveAt(proNode); //Remove original property
            eventList[evtNode].actors[actNode].actions[acnNode].properties.Insert(proNode - 1, tempPropClass); //Insert buffer above original property

            treeView1.BeginUpdate(); //TreeView can't paint

            if (treeView1.Nodes[evtNode].Nodes[actNode].Nodes[acnNode].Nodes[proNode] == treeView1.Nodes[evtNode].Nodes[actNode].Nodes[acnNode].Nodes[treeView1.Nodes[evtNode].Nodes[actNode].Nodes[acnNode].Nodes.Count - 1])
            {
                isLastNode = true;
            }

            TreeNode tempPropNode = treeView1.Nodes[evtNode].Nodes[actNode].Nodes[acnNode].Nodes[proNode]; //Put selected node in a buffer
            treeView1.Nodes[evtNode].Nodes[actNode].Nodes[acnNode].Nodes.RemoveAt(proNode); //Remove original node

            if (isLastNode == true)
            {
                treeView1.Nodes[evtNode].Nodes[actNode].Nodes[acnNode].Nodes.Insert(proNode, tempPropNode); //Re-insert the node above where it was

                treeView1.SelectedNode = treeView1.Nodes[evtNode].Nodes[actNode].Nodes[acnNode].Nodes[proNode];
            }

            else
            {
                treeView1.Nodes[evtNode].Nodes[actNode].Nodes[acnNode].Nodes.Insert(proNode - 1, tempPropNode); //Re-insert the node above where it was

                treeView1.SelectedNode = treeView1.Nodes[evtNode].Nodes[actNode].Nodes[acnNode].Nodes[proNode - 1];
            }

            treeView1.EndUpdate(); //TreeView can paint

            isLastNode = false;
        }

        private void movePropDown()
        {
            propertyClass tempPropClass = eventList[evtNode].actors[actNode].actions[acnNode].properties[proNode]; //Put the action in a buffer
            eventList[evtNode].actors[actNode].actions[acnNode].properties.RemoveAt(proNode); //Remove original property
            eventList[evtNode].actors[actNode].actions[acnNode].properties.Insert(proNode + 1, tempPropClass); //Insert buffer below original property

            treeView1.BeginUpdate(); //TreeView can't paint

            TreeNode tempPropNode = treeView1.Nodes[evtNode].Nodes[actNode].Nodes[acnNode].Nodes[proNode]; //Put selected node in a buffer
            treeView1.Nodes[evtNode].Nodes[actNode].Nodes[acnNode].Nodes.RemoveAt(proNode); //Remove original node
            treeView1.Nodes[evtNode].Nodes[actNode].Nodes[acnNode].Nodes.Insert(proNode + 1, tempPropNode); //Insert buffer below original node

            treeView1.EndUpdate();
        }

        #endregion

        #region File operations

        #region File loading

        //Call loading function when the open button is pressed
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load();
        }

        //Load file and parse data
        private void load()
        {
            //Open the open file dialog and listen for the user's input
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                //Check if a file has already been loaded
                if (isLoaded == true)
                {
                    reset();
                }

                //A file has been loaded
                isLoaded = true;

                //Load the file data for the program to use
                data = Helpers.LoadBinary(openFileDialog1.FileName);

                //Check to make sure the file is the right kind. There's no magic, but the first four bytes
                //make up an integer that's always 0x40/64 dec. Not sure if this is neccessary, but better
                //safe than sorry.
                if (Helpers.Read32(data, 0) != 64)
                {
                    MessageBox.Show("Selected file is not a valid event list.");

                    isLoaded = false;

                    return;
                }

                //Initialize the data parser
                DatParser dat = new DatParser();

                //Parse the data and get the event list
                eventList = dat.parse(data);

                //Grab float list from dat
                floatDataList = dat.getFloatList();

                //Grab integer list from dat
                intDataList = dat.getIntList();

                //Grab string bank from dat
                stringData = dat.getStringData();

                //Load the property class' data
                loadPropertyData();

                //Fill the TreeView using eventList
                fillTreeview();
            }
        }

        //Load data into property classes
        private void loadPropertyData()
        {
            //This long-winded function loads the data in the property classes into each class's dynamic propData
            //variable. Three of the four data types just pull an index from their respective List<>. Strings,
            //however, are read from a byte[] using Helpers, since they are referenced by an offset into
            //the string bank rather than an index.
            foreach (eventClass evClass in eventList)
            {
                foreach (actorClass actorClass in evClass.actors)
                {
                    foreach (actionClass actionClass in actorClass.actions)
                    {
                        foreach (propertyClass propClass in actionClass.properties)
                        {
                            switch (propClass.dataType)
                            {
                                //Load a single float
                                case 0:
                                    propClass.propData = floatDataList[propClass.dataIndex];
                                    break;

                                //Load a vector3
                                case 1:
                                    propClass.propData = new Vector3(floatDataList[propClass.dataIndex],
                                        floatDataList[propClass.dataIndex + 1], floatDataList[propClass.dataIndex + 2]);
                                    break;

                                //Not valid. Could have been used in earlier builds of the game for shorts,
                                //but it has no use now.
                                case 2:
                                    MessageBox.Show("Oh, fiddlesticks. What now?");
                                    break;

                                //Load an integer
                                case 3:
                                    propClass.propData = intDataList[propClass.dataIndex];
                                    break;

                                //Load a string
                                case 4:

                                    if (propClass.dataIndex >= stringData.Length)
                                    {
                                        propClass.propData = "null";

                                        break;
                                    }

                                    propClass.propData = Helpers.ReadString(stringData, propClass.dataIndex);
                                    break;
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region File saving

        //Create new file
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isLoaded == true)
            {
                DialogResult result = saveFileDialog1.ShowDialog();

                if (result == DialogResult.OK)
                {
                    DatExporter exporter = new DatExporter();

                    exporter.export(eventList, saveFileDialog1.FileName);
                }
            }
        }

        //Save over opened file
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isLoaded == true)
            {
                DatExporter exporter = new DatExporter();

                exporter.export(eventList, openFileDialog1.FileName);
            }
        }

        #endregion

        #endregion

        #region TreeView functions

        //Fill TreeView
        private void fillTreeview()
        {
            //This will fill the TreeView with the elements from the file that was loaded.

            //Stop TreeView from rendering the tree
            treeView1.BeginUpdate();

            //Clear the previous load's TreeView
            treeView1.Nodes.Clear();

            foreach (eventClass evClass in eventList)
            {
                //Create event node
                TreeNode evNode = new TreeNode();

                evNode.Text = evClass.eventName;

                evNode.ToolTipText = "Actors: " + evClass.actors.Count + Environment.NewLine;

                foreach (actorClass actClass in evClass.actors)
                {
                    //Create actor node
                    TreeNode actrNode = new TreeNode();

                    actrNode.Text = actClass.name;

                    actrNode.ToolTipText = "Actions: " + actClass.actions.Count + Environment.NewLine;

                    foreach (actionClass actnClass in actClass.actions)
                    {
                        //Create action node
                        TreeNode actnNode = new TreeNode();

                        actnNode.Text = actnClass.name;

                        actnNode.ToolTipText = "Properties: " + actnClass.properties.Count;

                        foreach (propertyClass propClass in actnClass.properties)
                        {
                            //Create property node
                            TreeNode propNode = new TreeNode();

                            propNode.Text = propClass.name;

                            propNode.ToolTipText = "Data: " + propClass.propData.ToString() + Environment.NewLine;

                            //Add property node to action node
                            actnNode.Nodes.Add(propNode);
                        }

                        //Add action node to actor node
                        actrNode.Nodes.Add(actnNode);
                    }

                    //Add actor node to event node
                    evNode.Nodes.Add(actrNode);
                }

                //Add event node to TreeView
                treeView1.Nodes.Add(evNode);
            }

            //TreeView can render the tree again
            treeView1.EndUpdate();
        }

        //Bring up context menus
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //Grab the selected node based on the mouse's position in the tree.
                //Is there a better way to select nodes with the right mouse button?
                treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);

                //Setting the position of the mouse so the context menu is
                //position correctly
                Point pnt = new Point(MousePosition.X, MousePosition.Y);

                //Based on the level of the node, we're going to pull up the
                //correct context menu.
                switch ((int)treeView1.SelectedNode.Level)
                {
                    case 0:
                        eventMenu.Show(pnt);
                        break;
                    case 1:
                        actorMenu.Show(pnt);
                        break;
                    case 2:
                        actionMenu.Show(pnt);
                        break;
                    case 3:
                        propMenu.Show(pnt);
                        break;
                }
            }
        }

        //Bring up element controls after select
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Gets the selected nodes
            getSelectedNodes();

            //Get rid of the current control
            controlPanel.Controls.Clear();

            //Load a new control
            createElementControls();
        }

        //Update node index variables
        private void getSelectedNodes()
        {
            //Depending on the level the node is at, we'll update different TreeView index variables.
            switch (treeView1.SelectedNode.Level)
            {
                //Event
                case 0:
                    evtNode = treeView1.SelectedNode.Index;
                    break;

                //Event and Actor
                case 1:
                    evtNode = treeView1.SelectedNode.Parent.Index;
                    actNode = treeView1.SelectedNode.Index;
                    break;

                //Event, Actor, and Action
                case 2:
                    evtNode = treeView1.SelectedNode.Parent.Parent.Index;
                    actNode = treeView1.SelectedNode.Parent.Index;
                    acnNode = treeView1.SelectedNode.Index;
                    break;

                //Event, Actor, Action, and Property
                case 3:
                    evtNode = treeView1.SelectedNode.Parent.Parent.Parent.Index;
                    actNode = treeView1.SelectedNode.Parent.Parent.Index;
                    acnNode = treeView1.SelectedNode.Parent.Index;
                    proNode = treeView1.SelectedNode.Index;
                    break;
            }
        }

        #endregion

        #region Utility

        //Initializes the form
        public MainUI()
        {
            InitializeComponent();
        }

        //Loads up user controls
        private void createElementControls()
        {
            //A proper user control will be created depending on the selected node's level
            //in the tree.
            switch (treeView1.SelectedNode.Level)
            {
                //Load event control
                case 0:
                    EventControl evCtrl = new EventControl(this);

                    evCtrl.loadEventUI(eventList[evtNode]);

                    evCtrl.Dock = DockStyle.Fill;

                    controlPanel.Controls.Add(evCtrl);

                    break;

                //Load actor control
                case 1:
                    ActorControl actCtrl = new ActorControl(this);

                    actCtrl.loadActorUI(eventList[evtNode].actors[actNode]);

                    actCtrl.Dock = DockStyle.Fill;

                    controlPanel.Controls.Add(actCtrl);

                    break;

                //Load action control
                case 2:
                    ActionControl acnCtrl = new ActionControl(this);

                    acnCtrl.loadActionUI(eventList[evtNode].actors[actNode].actions[acnNode]);

                    acnCtrl.Dock = DockStyle.Fill;

                    controlPanel.Controls.Add(acnCtrl);

                    break;

                //Load property control
                case 3:
                    PropertyControl propCtrl = new PropertyControl(this);

                    propCtrl.loadPropUI(eventList[evtNode].actors[actNode].actions[acnNode].properties[proNode]);

                    propCtrl.Dock = DockStyle.Fill;

                    controlPanel.Controls.Add(propCtrl);

                    break;
            }
        }

        //Resets major variables
        private void reset()
        {
            eventList.Clear();

            treeView1.Nodes.Clear();

            Array.Clear(data, 0, data.Length);

            controlPanel.Controls.Clear();
        }

        //Exits the application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

    }
}

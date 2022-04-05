using System;
using System.Windows.Forms;
using System.Collections;

using Opc.Ua;
using Opc.Ua.Configuration;
using Opc.Ua.Client;
using Opc.Ua.Sample.Controls;
using System.Collections.Generic;

namespace MinimalClient
{
    public partial class MinimalClient : Form
    {
        private ApplicationConfiguration _config;
        private Session _session;

        private Subscription subscription;
        private MonitoredItem monitoredItem;

        private Hashtable oNode = new Hashtable();

        public MinimalClient()
        {
            InitializeComponent();

            if (EndpointCB.Items.Count > 0)
                EndpointCB.SelectedIndex = 0;

            //"1 - Create a config"
            _config = CreateOpcUaAppConfiguration();
        }
        
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            string endPointUrl = this.EndpointCB.Text;

            //2 - Create Session
            _session = Session.Create(_config, new ConfiguredEndpoint(null, new EndpointDescription(endPointUrl)), true, "", 60000, null, null);
            
            //3 - Show the server namespace
            //browseTreeCtrl1.SetView(_session, BrowseViewType.Objects, null);

            ReferenceDescriptionCollection refs;
            byte[] continuationPoint;

            _session.Browse(null, null, ObjectIds.ObjectsFolder, 0u, BrowseDirection.Forward, ReferenceTypeIds.HierarchicalReferences, true, (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, out continuationPoint, out refs);


            makeTree(refs);

            //BrowsTreeControl을 사용하지 않는 경우 아래 코드를 사용하여 AddressSpace를 순회할 수 있다.

            //ReferenceDescriptionCollection refs;
            //byte[] continuationPoint;

            //_session.Browse(null, null, ObjectIds.ObjectsFolder, 0u, BrowseDirection.Forward, ReferenceTypeIds.HierarchicalReferences, true, (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, out continuationPoint, out refs);

            //foreach (var rd in refs)
            //{
            //    Console.WriteLine("{0}: {1}, {2}", rd.DisplayName, rd.BrowseName, rd.NodeClass);
            //    ReferenceDescriptionCollection nextRefs;
            //    byte[] nextCp;
            //    _session.Browse(null, null, ExpandedNodeId.ToNodeId(rd.NodeId, _session.NamespaceUris), 0u, BrowseDirection.Forward, ReferenceTypeIds.HierarchicalReferences, true, (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, out nextCp, out nextRefs);
            //    foreach (var nextRd in nextRefs)
            //    {
            //        Console.WriteLine("+ {0}: {1}, {2}", nextRd.DisplayName, nextRd.BrowseName, nextRd.NodeClass);
            //    }
            //}


        }

        private void makeTree(ReferenceDescriptionCollection refs)
        {
            foreach (var rd in refs)
            {
                TreeNode item = new TreeNode(rd.DisplayName.ToString());
                if (rd.NodeClass == NodeClass.Variable)
                {
                    item.Tag = rd;
                }

                Console.WriteLine("{0}: {1}, {2}", rd.DisplayName, rd.BrowseName, rd.NodeClass);


                ReferenceDescriptionCollection nextRefs;
                byte[] nextCp;
                _session.Browse(null, null, ExpandedNodeId.ToNodeId(rd.NodeId, _session.NamespaceUris), 0u, BrowseDirection.Forward, ReferenceTypeIds.HierarchicalReferences, true, (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, out nextCp, out nextRefs);

                makeTreeChild(item, nextRefs);
                //foreach (var nextRd in nextRefs)
                //{
                //    Console.WriteLine("+ {0}: {1}, {2}", nextRd.DisplayName, nextRd.BrowseName, nextRd.NodeClass);

                //}

                ItemTree.Nodes.Add(item);
            }
        }

        private void makeTreeChild(TreeNode parent, ReferenceDescriptionCollection refs)
        {
            foreach (var rd in refs)
            {
                TreeNode item = new TreeNode(rd.DisplayName.ToString());
                if (rd.NodeClass == NodeClass.Variable)
                {
                    item.Tag = rd;
                }

                Console.WriteLine("{0}: {1}, {2}", rd.DisplayName, rd.BrowseName, rd.NodeClass);


                ReferenceDescriptionCollection nextRefs;
                byte[] nextCp;
                _session.Browse(null, null, ExpandedNodeId.ToNodeId(rd.NodeId, _session.NamespaceUris), 0u, BrowseDirection.Forward, ReferenceTypeIds.HierarchicalReferences, true, (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, out nextCp, out nextRefs);

                makeTreeChild(item, nextRefs);
                //foreach (var nextRd in nextRefs)
                //{
                //    Console.WriteLine("+ {0}: {1}, {2}", nextRd.DisplayName, nextRd.BrowseName, nextRd.NodeClass);

                //}

                parent.Nodes.Add(item);
            }
        }
        private void getNode(ReferenceDescriptionCollection refs)
        {
            foreach (var rd in refs)
            {
                Console.WriteLine("{0}: {1}, {2}", rd.DisplayName, rd.BrowseName, rd.NodeClass);
                if (oNode.ContainsKey(rd.NodeId.ToString()) == false)
                    oNode.Add(rd.NodeId.ToString(), rd);


                ReferenceDescriptionCollection nextRefs;
                byte[] nextCp;
                _session.Browse(null, null, ExpandedNodeId.ToNodeId(rd.NodeId, _session.NamespaceUris), 0u, BrowseDirection.Forward, ReferenceTypeIds.HierarchicalReferences, true, (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, out nextCp, out nextRefs);

                getNodeR(nextRefs);
                //foreach (var nextRd in nextRefs)
                //{
                //    Console.WriteLine("+ {0}: {1}, {2}", nextRd.DisplayName, nextRd.BrowseName, nextRd.NodeClass);

                //}
            }
        }

        private void getNodeR(ReferenceDescriptionCollection refs)
        {
            foreach (var rd in refs)
            {
                Console.WriteLine("{0}: {1}, {2}", rd.DisplayName, rd.BrowseName, rd.NodeClass);
                if (oNode.ContainsKey(rd.NodeId.ToString()) == false)
                    oNode.Add(rd.NodeId.ToString(), rd);


                ReferenceDescriptionCollection nextRefs;
                byte[] nextCp;
                _session.Browse(null, null, ExpandedNodeId.ToNodeId(rd.NodeId, _session.NamespaceUris), 0u, BrowseDirection.Forward, ReferenceTypeIds.HierarchicalReferences, true, (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, out nextCp, out nextRefs);

                getNodeR(nextRefs);
                //foreach (var nextRd in nextRefs)
                //{
                //    Console.WriteLine("+ {0}: {1}, {2}", nextRd.DisplayName, nextRd.BrowseName, nextRd.NodeClass);

                //}
            }
        }

        private ApplicationConfiguration CreateOpcUaAppConfiguration()
        {
            var config = new ApplicationConfiguration()
            {
                ApplicationName = "MinimalClient",
                ApplicationType = ApplicationType.Client,
                SecurityConfiguration = new SecurityConfiguration
                {
                    ApplicationCertificate = new CertificateIdentifier(),
                    AutoAcceptUntrustedCertificates = true   //신뢰할 수 없는 인증서 허용
                },
                ClientConfiguration = new ClientConfiguration { DefaultSessionTimeout = 60000 }
            };
            
            config.Validate(ApplicationType.Client);

            //신뢰할 수 없는 인증서 허용
            if (config.SecurityConfiguration.AutoAcceptUntrustedCertificates)
            {
                config.CertificateValidator.CertificateValidation += (s, e) =>
                {
                    e.Accept = (e.Error.StatusCode == StatusCodes.BadCertificateUntrusted);
                };
            }

            return config;
        }

        private void MinimalClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }

        public void Disconnect()
        {
            if (_session != null)
            {
                _session.Close();
                _session = null;
            }            
        }


        private void ItemTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ReferenceDescription rd = (ReferenceDescription)e.Node.Tag;
            if (rd.NodeClass == NodeClass.Variable)
            {
                txtNodeID.Text = rd.NodeId.ToString();
                txtNodeID.Tag = rd;
            }

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                NodeId nd = new NodeId(txtNodeID.Text);
                txtValue.Text = ReadValue(nd).Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error : " + ex.Message);
            }
        }

        private DataValue ReadValue(NodeId nodeId)
        {
            return _session.ReadValue(nodeId);
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                NodeId nd = new NodeId(txtNodeID.Text);
                ReferenceDescription rd = (ReferenceDescription)txtNodeID.Tag;
                
                writeValue(nd, txtValue.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error : " + ex.Message);
            }
        }

        private bool writeValue(NodeId nodeId, string writeValue)
        {
      

            WriteValueCollection nodesToWrite = new WriteValueCollection();

            WriteValue itemToWrite = new WriteValue();

            itemToWrite.NodeId = nodeId;
            itemToWrite.AttributeId = Attributes.Value;
            
            DataValue dv = new DataValue(Convert.ToInt16(writeValue));
            
            itemToWrite.Value = dv;


            nodesToWrite.Add(itemToWrite);

            StatusCodeCollection scc = null;
            DiagnosticInfoCollection diagnosInfos = null;

            ResponseHeader resp = _session.Write(
                null, nodesToWrite, out scc, out diagnosInfos
                );

            if (StatusCode.IsBad(scc[0]))
            {
                ServiceResult result = ClientBase.GetResult(scc[0], 0, diagnosInfos, resp);
                throw new ServiceResultException(result);
                
            }

            return true;
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            if (txtNodeID.Text.Length > 0)
            {
                if (lstNodes.Items.Contains(txtNodeID.Text) == false)
                {

                    lstNodes.Items.Add(txtNodeID.Text);
                }
            }
        }

        private void btnRemoveList_Click(object sender, EventArgs e)
        {
            if (lstNodes.SelectedItem != null)
            {
                lstNodes.Items.Remove(lstNodes.SelectedItem);
            }
        }

        private void btnCreateSubs_Click(object sender, EventArgs e)
        {
            subscription = new Subscription(_session.DefaultSubscription)
            {
                PublishingEnabled = true,
                PublishingInterval = 1000
            };

            var list = new List<MonitoredItem> { };
            foreach (object itm in lstNodes.Items)
            {
                list.Add(new MonitoredItem(subscription.DefaultItem)
                {
                    DisplayName = itm.ToString(),
                    StartNodeId = itm.ToString()
                });
            }
            list.ForEach(i => i.Notification += new MonitoredItemNotificationEventHandler(OnNotification));
            subscription.AddItems(list);

            _session.AddSubscription(subscription);

            subscription.Create();

        }

        private void OnNotification(MonitoredItem item, MonitoredItemNotificationEventArgs e)
        {
            MonitoredItemNotification notification = e.NotificationValue as MonitoredItemNotification;
            foreach (var value in item.DequeueValues())
            {
                this.Invoke(new MethodInvoker(
                    delegate ()
                    {
                        txtSubs.AppendText(String.Format("{0} : {1}\r\n", item.StartNodeId, value.Value.ToString()));
                        txtSubs.ScrollToCaret();
                    }));
                
            }
        }

        private void btnRemoveSubs_Click(object sender, EventArgs e)
        {
            subscription.Delete(true);
        }
    }


}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TV_user
{
    public partial class TV_user: UserControl
    {


        #region 增加AfterCheck事件
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void AfterCheckEventHandler(object sender, System.Windows.Forms.TreeViewEventArgs e);
        /// <summary>
        /// 节点check事件
        /// </summary>
        public event AfterCheckEventHandler AfterCheckEvent;




        //public event AfterCheckEventHandler AfterCheck
        //{
        //    add
        //    {
        //        AfterCheckEvent = (AfterCheckEventHandler)System.Delegate.Combine(AfterCheckEvent, value);
        //    }
        //    remove
        //    {
        //        AfterCheckEvent = (AfterCheckEventHandler)System.Delegate.Remove(AfterCheckEvent, value);
        //    }
        //}
        #endregion


        #region 增加AfterSelect事件
        //public delegate void AfterSelectEventHandler(object sender, System.Windows.Forms.TreeViewEventArgs e);
        //private AfterSelectEventHandler AfterSelectEvent;

        //public event AfterSelectEventHandler AfterSelect
        //{
        //    add
        //    {
        //        AfterSelectEvent = (AfterSelectEventHandler)System.Delegate.Combine(AfterSelectEvent, value);
        //    }
        //    remove
        //    {
        //        AfterSelectEvent = (AfterSelectEventHandler)System.Delegate.Remove(AfterSelectEvent, value);
        //    }
        //}
        #endregion

        #region 返回所有节点的属性
        /// <summary>
        /// 返回所有节点
        /// </summary>
        public System.Windows.Forms.TreeNodeCollection Nodes
        {
            get
            {
                return this.treeView1.Nodes;
            }

        }
        #endregion

        #region 清除所有节点的方法
        /// <summary>
        /// 清除所有节点的方法
        /// </summary>
        public void Clear()
        {
            this.treeView1.Nodes.Clear();
        }
        #endregion


        #region 展开所有节点的方法
        /// <summary>
        /// 展开所有节点的方法
        /// </summary>
        public void ExpandAll()
        {
            this.treeView1.ExpandAll();
        }
        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        public TV_user()
        {
            InitializeComponent();
        }

        private void TV_user_Load(object sender, EventArgs e)
        {

        }

        private void TreeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            Console.Write(e.Node.Name+"            ");
            Console.WriteLine(e.Node.Text);

            AfterCheckEvent?.Invoke(sender, e);


        }

        private void CheckChildNode(TreeNode Node)
        {

            if (Node.Checked == true)
            {
                Node.ImageIndex = 1;
                Node.SelectedImageIndex = 1;
            }
            else
            {
                Node.ImageIndex = 0;
                Node.SelectedImageIndex = 0;
            }

            if (Node.FirstNode == null)
            {
                return;
            }
            else
            {
                Node.FirstNode.Checked = Node.Checked;
                Node = Node.FirstNode;
                CheckChildNode(Node);
            }

            while (!(Node.NextNode == null))
            {
                Node.NextNode.Checked = Node.Checked;
                Node = Node.NextNode;
                CheckChildNode(Node);
            }

        }
        private void CheckParentNode(ref TreeNode Node)
        {


            short s = 0;


            s = (short)Node.ImageIndex;

            if (Node.Parent == null)
            {
                return;
            }

            Node = Node.Parent;
            for (int i = 0; i <= Node.GetNodeCount(false) - 1; i++)
            {

                if (Node.Nodes[i].ImageIndex != s)
                {
                    s = (short)2;
                    break;
                }
            }
            if (s == 0)
            {
                Node.Checked = false;
            }
            else
            {
                Node.Checked = true;
            }
            Node.ImageIndex = s;
            Node.SelectedImageIndex = s;
            CheckParentNode(ref Node);

        }

        /// <summary>
        /// 选择节点的方法
        /// </summary>
        /// <param name="Node"></param>
        public void CheckNode(TreeNode Node)
        {
            this.treeView1.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterCheck);

            CheckChildNode(Node);
            CheckParentNode(ref Node);

            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterCheck);
        }
    }
}

using System;
using System.Collections.Generic;

namespace PowerWorkflow
{

    public class ThreadFactory
    {

        public ThreadDefinition CreateThreadDefinition(Template.Root root)
        {

            ThreadDefinition result = new ThreadDefinition();
            return result;
        }


        public ThreadInstance NewThreadInstance(ThreadDefinition threadDefinition)
        {

            ThreadInstance result = new ThreadInstance();
            return result;
        }

        public void InitialThreadInstance(ThreadInstance instance) { }

        public void DriveThreadInstance(NodeInstance node, ThreadRole role, ThreadAction action) { }

        public IList<NodeInstance> GetNodeInstances(ThreadInstance instance)
        {
            throw new NotImplementedException();
        }


        public NodeInstance GetCurrentNode(ThreadInstance instance)
        {
            throw new NotImplementedException();
        }

        public FormInstance GetForm(NodeInstance node, ThreadRole role)
        {
            throw new NotImplementedException();
        }
        public PageInstance GetPage(NodeInstance node, ThreadRole role)
        {
            throw new NotImplementedException();
        }
    }
}
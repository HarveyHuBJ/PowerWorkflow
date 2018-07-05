using System;

namespace PowerWorkflow.Workflow
{
    public static class PowerThreadDefaultNodes
    {

        private static Guid[] defaultIds = new Guid[]{
            Guid.Parse("1ac6ac18-3292-48c8-8642-534b1032ab55"),
            Guid.Parse("623d8d46-710a-4e2b-8c4c-6dfb9d7db12b"),
            Guid.Parse("775381f4-46bf-455a-959d-14182f8cacc9"),
            Guid.Parse("05240b84-6edc-4a5d-90a0-173a67389e59"),
            Guid.Parse("258ed202-d9fa-441d-889f-6f8be11af032")


        };

        public static PowerThreadNode DefaultStartNode
        {
            get
            {
                return new PowerThreadNode(defaultIds[0], "[Start]") { IsStart = true };
            }
        }

        public static PowerThreadNode DefaultEndNode
        {
            get
            {
                return new PowerThreadNode(defaultIds[1], "[End]") { IsEnd = true };
            }
        }


        public static PowerThreadNode MissFoundNode
        {
            get
            {
                return new PowerThreadNode(defaultIds[2], "[MissFoundNode]") { IsEnd = false };
            }
        }
    }
}
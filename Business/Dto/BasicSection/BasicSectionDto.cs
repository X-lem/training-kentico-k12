using System;

namespace Business.Dto.BasicSection
{
    public class BasicSectionDto
    {
        public int NodeId { get; set; }
        public Guid NodeGuid { get; set; }
        public string NodeAlias { get; set; }
        public string BasicSectionName { get; set; }
    }
}
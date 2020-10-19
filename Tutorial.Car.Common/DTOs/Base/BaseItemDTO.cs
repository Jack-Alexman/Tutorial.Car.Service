using System;

namespace Tutorial.Car.Common.DTOs.Base
{
    public interface IIdentifier
    {
        public long ID { get; set; }
    }

    public class BaseItemDTO : IIdentifier
    {
        public long ID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using cqgis.extensions;
using cqgis.extensions.xunit;
using Xunit;

namespace Tests.UnitTest
{ 
    public class Test_EventBus
    {
        [Fact]
        public  void Test_Subscription()
        {
            int count = 0;
            string Message = Guid.NewGuid()
                .Tostring16();
            var type = MessageBoxInfoEvent.MessageInfoType.Error;

            EventBus.Default.Subscribe<MessageBoxInfoEvent>(t =>
            {
                Interlocked.Increment(ref count);

                t.Message.ShouldBe(Message);
                t.Type.ShouldBe(type);
            });

            EventBus.Default.Publish(new MessageBoxInfoEvent(Message,type));
            count.ShouldBe(1);
             
        }




    }
}

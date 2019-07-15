
using TKBase.Framework.Redis.Internal.IO;
namespace TKBase.Framework.Redis.Internal.Commands
{
    class RedisBytes : RedisCommand<byte[]>
    {
        public RedisBytes(string command, params object[] args)
            : base(command, args)
        { }

        public override byte[] Parse(RedisReader reader)
        {
            return reader.ReadBulkBytes(true);
        }
    }
}

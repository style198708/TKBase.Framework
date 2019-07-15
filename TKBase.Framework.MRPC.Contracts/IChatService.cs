using TKBase.Framework.MRPC.Attributes;

namespace TKBase.Framework.MRPC.Contracts
{
    [MService]
    public interface IChatService
    {
        string Hi(string name);

        string Hi(string name, string content);

        string Hello(int age);

        string Hello(double age);
    }
}

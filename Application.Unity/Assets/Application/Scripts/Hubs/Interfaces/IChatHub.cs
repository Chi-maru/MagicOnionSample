using MagicOnion;
using Application.Shared.Hubs;
using System.Threading.Tasks;
using Application.Shared.MessagePackObjects;

namespace Application
{
    /// <summary>
    /// CLient -> Server��API
    /// </summary>
    public interface IChatHub : IStreamingHub<IChatHub, IChatHubReceiver>
    {
        /// <summary>
        /// �Q�����邱�Ƃ��T�[�o�ɓ`����
        /// </summary>
        /// <param name="userName">�Q���҂̖��O</param>
        /// <returns></returns>
        Task JoinAsync(PlayerDataMpo playerData);
        /// <summary>
        /// �ގ����邱�Ƃ��T�[�o�ɓ`����
        /// </summary>
        /// <returns></returns>
        Task LeaveAsync();
        /// <summary>
        /// ���b�Z�[�W���T�[�o�ɓ`����
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendMessageAsync(string message);
    }
}
using Application.Shared.Hubs;
using Application.Shared.MessagePackObjects;
using MagicOnion.Server.Hubs;

namespace Application.Server.Hubs
{
    public class ChatHub : StreamingHubBase<IChatHub, IChatHubReceiver>, IChatHub
    {
        IGroup room;
        string me;

        public async Task JoinAsync(PlayerDataMpo playerData)
        {
            //ルームは全員固定
            const string roomName = "SampleRoom";
            //ルームに参加&ルームを保持
            this.room = await this.Group.AddAsync(roomName);
            //自分の名前も保持
            me = playerData.Name;
            //参加したことをルームに参加している全メンバーに通知
            this.Broadcast(room).OnJoin(playerData);
        }

        public async Task LeaveAsync()
        {
            //ルーム内のメンバーから自分を削除
            await room.RemoveAsync(this.Context);
            //退室したことを全メンバーに通知
            this.Broadcast(room).OnLeave(me);
        }


        public async Task SendMessageAsync(string message)
        {
            //発言した内容を全メンバーに通知
            this.Broadcast(room).OnSendMessage(me, message);
        }

        protected override ValueTask OnDisconnected()
        {
            //nop
            return CompletedTask;
        }
    }
}

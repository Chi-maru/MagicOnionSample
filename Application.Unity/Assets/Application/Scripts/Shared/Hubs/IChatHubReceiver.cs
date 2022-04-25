namespace Application.Shared.Hubs
{
    /// <summary>
    /// Server -> ClientのAPI
    /// </summary>
    public interface IChatHubReceiver
    {
        /// <summary>
        /// 誰かがチャットに参加したことをクライアントに伝える。
        /// </summary>
        /// <param name="name">参加した人の名前</param>
        void OnJoin(string name);
        /// <summary>
        /// 誰かがチャットから退室したことをクライアントに伝える。
        /// </summary>
        /// <param name="name">退室した人の名前</param>
        void OnLeave(string name);
        /// <summary>
        /// 誰かが発言した事をクライアントに伝える。
        /// </summary>
        /// <param name="name">発言した人の名前</param>
        /// <param name="message">メッセージ</param>
        void OnSendMessage(string name, string message);
    }
}
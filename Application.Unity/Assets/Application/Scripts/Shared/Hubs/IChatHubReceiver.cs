namespace Application.Shared.Hubs
{
    /// <summary>
    /// Server -> Client��API
    /// </summary>
    public interface IChatHubReceiver
    {
        /// <summary>
        /// �N�����`���b�g�ɎQ���������Ƃ��N���C�A���g�ɓ`����B
        /// </summary>
        /// <param name="name">�Q�������l�̖��O</param>
        void OnJoin(string name);
        /// <summary>
        /// �N�����`���b�g����ގ��������Ƃ��N���C�A���g�ɓ`����B
        /// </summary>
        /// <param name="name">�ގ������l�̖��O</param>
        void OnLeave(string name);
        /// <summary>
        /// �N�����������������N���C�A���g�ɓ`����B
        /// </summary>
        /// <param name="name">���������l�̖��O</param>
        /// <param name="message">���b�Z�[�W</param>
        void OnSendMessage(string name, string message);
    }
}
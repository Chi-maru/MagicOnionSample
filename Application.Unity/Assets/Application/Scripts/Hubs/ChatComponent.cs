using Application.Shared.Hubs;
using Grpc.Core;
using MagicOnion.Client;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Application
{
    public class ChatComponent : MonoBehaviour, IChatHubReceiver
    {
        private Channel _channel;
        private IChatHub _chatHub;
        private bool _isJoin;

        //��M���b�Z�[�W
        public TMP_Text ChatText;

        //�����E�ގ�UI
        public Button JoinOrLeaveButton;
        public TMP_Text JoinOrLeaveButtonText;
        public TMP_InputField UserNameTextInput;

        //�e�L�X�g���MUI
        public Button SendMessageButton;
        public TMP_InputField ChatTextInput;

        // Start is called before the first frame update
        void Start()
        {
            Initialize().Forget();
        }

        private async Cysharp.Threading.Tasks.UniTaskVoid Initialize()
        {
            this._isJoin = false;

            //Client����Hub�̏�����
            this._channel = new Channel("localhost:5013", ChannelCredentials.Insecure);
            this._chatHub = await StreamingHubClient.ConnectAsync<IChatHub, IChatHubReceiver>(this._channel, this);

            //���b�Z�[�W���M�{�^���̓f�t�H���g��\��
            this.SendMessageButton.gameObject.SetActive(false);
            this.JoinOrLeaveButton.gameObject.SetActive(false);
            SendMessageButton.onClick.AddListener(SendMessage);
            JoinOrLeaveButton.onClick.AddListener(JoinOrLeave);

            UserNameTextInput.onValueChanged.AddListener(CheckUserNameInput);
        }

        // Update is called once per frame
        void Update()
        {

        }

        async void OnDestroy()
        {
            await this._chatHub.DisposeAsync();
            await this._channel.ShutdownAsync();
        }

        private void CheckUserNameInput(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                this.JoinOrLeaveButton.gameObject.SetActive(false);
            }
            else
            {
                this.JoinOrLeaveButton.gameObject.SetActive(true);
            }
        }

        #region Client -> Server

        /// <summary>
        /// �Q�����ĂȂ�������Q������B
        /// �Q�����Ă���ގ�����B
        /// </summary>
        public async void JoinOrLeave()
        {
            if (this._isJoin)
            {
                await this._chatHub.LeaveAsync();
                this._isJoin = false;
                this.JoinOrLeaveButtonText.text = "��������";
                //���b�Z�[�W���M�{�^�����\����
                this.SendMessageButton.gameObject.SetActive(false);
            }
            else
            {
                await this._chatHub.JoinAsync(this.UserNameTextInput.text);
                this._isJoin = true;
                this.JoinOrLeaveButtonText.text = "�ގ�����";
                //���b�Z�[�W���M�{�^����\��
                this.SendMessageButton.gameObject.SetActive(true);
            }
        }

        /// <summary>
        /// ���b�Z�[�W�𑗐M
        /// </summary>
        public async void SendMessage()
        {
            //�������ĂȂ������牽�����Ȃ�
            if (!this._isJoin)
                return;

            await this._chatHub.SendMessageAsync(this.ChatTextInput.text);
        }


        #endregion

        #region Client <- Server

        public void OnJoin(string name)
        {
            this.ChatText.text += $"\n{name}���񂪓������܂���";
        }

        public void OnLeave(string name)
        {
            this.ChatText.text += $"\n{name}���񂪑ގ����܂���";
        }

        public void OnSendMessage(string name, string message)
        {
            this.ChatText.text += $"\n{name}�F{message}";
        }
        #endregion
    }
}
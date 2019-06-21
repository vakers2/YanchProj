<template>
  <div>
    You're chatting with {{ $route.params.userId }}
    <div class="message-container">
      <message
        class="message"
        v-for="(message, index) in messages"
        :key="index"
        :own="message.own"
        :info="message"
      />
      <v-textarea
        v-model="text"
        class="message-input"
        rows="1"
        color="#0d2882"
        auto-grow
        outline
        label="Write a message..."
      />
    </div>
  </div>
</template>

<script>
import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr';
import api from '../../api';
import Message from './message';

const messages = [
  { text: 'Message', userName: 'Gamer', creationTime: '23:21' },
  { text: 'My message', own: true, userName: 'Gamer', creationTime: '23:21' },
  { text: 'My message', own: true, userName: 'Gamer', creationTime: '23:21' },
  { text: 'Message', userName: 'Gamer', creationTime: '23:21' },
  { text: 'Message', userName: 'Gamer', creationTime: '23:21' },
  {
    text:
      'My message message message message message message message message message message message',
    own: true,
    userName: 'Gamer',
    creationTime: '23:21'
  },
  { text: 'My message', own: true, userName: 'Gamer', creationTime: '23:21' },
  { text: 'Message', userName: 'Gamer', creationTime: '23:21' },
  { text: 'Message', userName: 'Gamer', creationTime: '23:21' },
  { text: 'My message', own: true, userName: 'Gamer', creationTime: '23:21' },
  { text: 'My message', own: true, userName: 'Gamer', creationTime: '23:21' },
  { text: 'Message', userName: 'Gamer', creationTime: '23:21' }
];

export default {
  components: {
    Message
  },
  created() {
    this.connection = new this.$signalR.HubConnectionBuilder()
      .withUrl('/chat/' + this.$route.params.id)
      .configureLogging(this.$signalR.LogLevel.Error)
      .build();

    api.chat.get.getMessages(this.$route.params.id).then(res => {
      this.messages = res.data;
    });
  },
  mounted() {
    this.connection.start();

    this.connection.invoke('ConnectToChatAsync', this.$route.params.id)

    this.connection.on('message', data => {
      this.messages.push(data);
    });
  },
  methods: {
    sendMessage() {
      this.connection.invoke(
        'SendMessageAsync',
        this.$route.params.id,
        this.name,
        this.text
      );

      this.text = '';
    }
  },
  data() {
    return {
      connection: null,
      messages: messages,
      text: ''
    };
  },
  computed: mapState(['name'])
};
</script>

<style scoped>
.message-container {
  display: flex;
  flex-direction: column;
  max-width: 60em;
  margin: 2em auto;
}

.message {
  align-self: flex-start;
}

.own {
  align-self: flex-end;
}

.message-input {
  position: sticky;
  margin: 1em 0.5em !important;
}
</style>
<template>
  <v-container>
    <v-layout row class="text-xs-center">
      <v-container style="position: relative;top: 13%;" class="text-xs-center">
        <v-card class="login-card" flat>
          <v-card-title primary-title>
            <h4>Create post</h4>
          </v-card-title>
          <v-form>
            <v-text-field v-model="title" prepend-icon="event_note" name="Title" label="Title"></v-text-field>
            <v-textarea
              name="Description"
              outline
              v-model="description"
              label="Description"
              auto-grow
            ></v-textarea>
            <v-card-actions>
              <v-btn @click="createPost()" class="btn btn-primary text-white" large block>Create</v-btn>
            </v-card-actions>
          </v-form>
        </v-card>
      </v-container>
    </v-layout>
  </v-container>
</template>

<script>
import api from '../../api';

export default {
  name: 'create-post',
  methods: {
    createPost: function() {
      if (this.title && this.description) {
        api.post.post.create(this.title, this.description)
        this.$router.push('/');
      }
    }
  },
  data() {
    return {
      title: '',
      description: ''
    };
  }
};
</script>

<style scoped>
.container {
  width: 500px;
}

.login-card {
  border: solid 1px black;
  padding: 10px;
}

.text-white {
  color: #ffffff;
}
</style>
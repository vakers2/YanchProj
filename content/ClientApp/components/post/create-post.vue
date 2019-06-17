<template>
  <v-container>
    <v-layout row class="text-xs-center">
      <v-container style="position: relative;top: 13%;" class="text-xs-center">
        <v-card class="login-card" flat>
          <v-card-title primary-title>
            <h4>Create post</h4>
          </v-card-title>
          <v-form>
            <v-text-field
              v-model="title"
              class="text-input"
              prepend-icon="event_note"
              name="Title"
              label="Title"
              :rules="titleRules"
              required
            ></v-text-field>
            <v-textarea
              name="Description"
              outline
              v-model="description"
              label="Description"
              auto-grow
              :rules="descriptionRules"
              :counter="rules.DESCRIPTION_MAX"
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

const rules = {
  DESCRIPTION_MAX: 1000
};

export default {
  name: 'create-post',
  methods: {
    createPost: function() {
      if (this.title && this.description) {
        api.post.post
          .create(this.title, this.description)
          .then(res => {
            this.$router.push('/');
          })
          .catch(function(error) {
            alert(error);
          });
      }
    }
  },
  data() {
    return {
      title: '',
      description: '',
      titleRules: [v => !!v || 'Title is required'],
      descriptionRules: [
        v =>
          (v.length <= rules.DESCRIPTION_MAX) ||
          `Description must be less than ${rules.DESCRIPTION_MAX} characters`
      ],
      rules: rules
    };
  }
};
</script>

<style scoped>
.container {
  max-width: 500px;
}

.login-card {
  background-color: transparent !important;
  padding: 10px;
}

.text-input {
  margin-bottom: 0.5em;
}

.text-white {
  color: #ffffff;
}
</style>
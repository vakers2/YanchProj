<template>
  <div class="container">
    <div class="row">
      <div class="col-sm-1"></div>
      <div class="col-sm-12">
        <card
          class="post"
          v-for="(post, index) in posts"
          :key="index"
          :title="post.title"
          :description="post.description"
          :owner="post.owner"
          :time="post.creationDate"
        />
      </div>
      <div class="col-sm-1"></div>
    </div>
    <spinner :loading="loading" full></spinner>
  </div>
</template>

<script>
import Post from './post/post';
import Card from './basic/app-card';
import Spinner from './basic/app-spinner';

import api from '../api';

export default {
  components: {
    Post,
    Spinner,
    Card
  },
  created() {
    api.post.get
      .getAll()
      .then(res => {
        this.posts = res.data;
      })
      .finally(() => (this.loading = false));
  },
  data() {
    return {
      posts: [],
      loading: true
    };
  }
};
</script>

<style>
.container {
  position: relative;
}

.row {
  justify-content: center;
}

.post {
  margin-bottom: 3em;
}
</style>

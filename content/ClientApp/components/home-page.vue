<template>
  <div class="container">
    <div class="row">
      <div class="col-sm-2"></div>
      <div class="col-sm-8 post-container">
        <post class="post" v-for="(post, index) in posts" :key="index" :post="post" />
      </div>
      <div class="col-sm-2"></div>
    </div>
    <spinner :loading="loading" full></spinner>
  </div>
</template>

<script>
import Post from './post/post';
import Spinner from './basic/app-spinner'

import api from '../api'

export default {
  components: {
    Post,
    Spinner
  },
  created() {
    api.post.get.getAll()
    .then(res => {
      this.posts = res.data
    })
    .finally(() => this.loading = false)
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

.post-container {
  max-width: 600px;
}

.post {
  margin-bottom: 3em;
}
</style>

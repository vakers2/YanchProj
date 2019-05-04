<template>
  <div class="container">
    <div class="row">
      <div class="col-sm-2"></div>
      <div class="col-sm-8">
        <post v-for="(post, index) in posts" :key="index" :post="post" />
      </div>
      <div class="col-sm-2"></div>
    </div>
  </div>
</template>

<script>
import Post from './post/post';

const posts = [{title: "Hello", description: "Hello world", creationDate: "13.05.1999", owner: "Vlados"}]

export default {
  components: {
    Post
  },
  data() {
    return {
      posts
    };
  }
};
</script>

<style>
</style>

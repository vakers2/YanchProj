<template>
  <div class="post-container">
    <div class="content">
      <div class="header">
        <h1>{{post.title}}</h1>
        <p class="owner">by {{post.owner}}</p>
      </div>
      <p class="description">{{post.description}}</p>
      <div class="footer">{{DateString}}</div>
    </div>
  </div>
</template>

<script>
export default {
  computed: {
    DateString: function() {
      var date = new Date(this.post.creationDate)

      return date.toLocaleString() 
    }
  },
  props: {
    post: {
      type: Object,
      required: true
    }
  },
  data() {
    return {};
  }
};
</script>

<style scoped>
.post-container {
  border: 1px solid black;
}

.content {
  padding: 1.5em 2em 1em 2em;
}

.header {
  display: flex;
  margin-bottom: 1em;
  align-items: center;
  justify-content: left;
}

.owner {
  margin-left: 1em;
  color: #000000aa;
}

.description {
  font-size: 1.5em;
}

.footer {
    text-align: right;
    color: #000000aa;
}
</style>
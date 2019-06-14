<template>
  <v-layout>
    <v-flex xs12 sm6 offset-sm3>
      <v-card>
        <v-img v-if="img" :src="img" aspect-ratio="2.75"></v-img>

        <v-card-title primary-title>
          <div class="card-info">
            <h3 class="headline mb-0">{{ title }}</h3>
            <div>{{ description }}</div>
            <span v-if="owner" class="owner">by {{owner}}</span>
            <span v-if="time" class="time">{{DateString}}</span>
          </div>
        </v-card-title>

        <!-- <v-card-actions>
          <v-btn flat color="orange">Share</v-btn>
          <v-btn flat color="orange">Explore</v-btn>
        </v-card-actions>-->
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
export default {
  name: 'card',
  computed: {
    DateString: function() {
      var date = new Date(this.time);

      return date.toLocaleString();
    }
  },
  props: {
    title: {
      type: String,
      required: true
    },
    description: {
      type: String,
      default: 'No description'
    },
    owner: {
      type: String
    },
    time: {
      type: String
    },
    img: {
      type: String
    }
  },
  data() {
    return {};
  }
};
</script>

<style scoped>
.owner {
  position: absolute;
  bottom: 0;
  left: 0;
  font-size: 0.8em;
}

.time {
  position: absolute;
  bottom: 0;
  right: 0;
  font-size: 0.8em;
}

.card-info {
  width: 100%;
  position: relative;
  padding-bottom: 2em;
}
</style>
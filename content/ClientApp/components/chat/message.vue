<template>
  <div class="box bubble" :class="{ own: own }">
    <div class="name">{{info.userName}}</div>
    {{info.text}}
    <div class="time">{{info.creationTime}}</div>
  </div>
</template>

<script>
export default {
  props: {
    own: {
      type: Boolean,
      default: false
    },
    info: {
      type: Object,
      default: null
    }
  },
  data() {
    return {};
  }
};
</script>

<style scoped>
.box {
  margin: 1em 2em;
  border-radius: 15px;
  color: #fff;
  padding: 20px 0 5px 15px;
  min-width: 10em;
  max-width: 25em;
  font-weight: 800;
  position: relative;
}

.bubble {
  background: #0d88c2;
}

.own {
  background: #0da2e7;
}

.bubble:before {
  content: '';
  width: 0px;
  height: 0px;
  position: absolute;
  border-left: 15px solid transparent;
  border-right: 15px solid #0d88c2;
  border-top: 15px solid #0d88c2;
  border-bottom: 15px solid transparent;
  left: -16px;
  top: 0px;
}

.own:before {
  content: '';
  width: 0px;
  height: 0px;
  position: absolute;
  border-left: 15px solid #0da2e7;
  border-right: 15px solid transparent;
  border-top: 15px solid #0da2e7;
  border-bottom: 15px solid transparent;
  right: -16px;
  left: initial;
  top: 0px;
}

.name {
  position: absolute;
  top: 0.2em;
  left: 1em;
  font-weight: 400;
  font-size: 1rem;
}

.time {
  position: absolute;
  top: 0.2em;
  right: 0.5em;
  font-weight: 300;
}
</style>
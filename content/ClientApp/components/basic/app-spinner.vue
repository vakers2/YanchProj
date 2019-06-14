<template>
  <div v-if="loading" class="background-blur" :class="{ 'background-blur--full': full}">
    <v-progress-circular class="spinner" indeterminate color="purple"></v-progress-circular>
  </div>
</template>

<script>
export default {
  name: 'spinner',
  props: {
    loading: {
      type: Boolean,
      default: true
    },
    full: {
      type: Boolean,
      default: false
    }
  },
  data() {
    return {
      selected: null
    };
  }
};
</script>

<style scoped>
.background-blur {
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: rgba(236, 235, 235, 0.288);
}

.background-blur--full {
  position: fixed;
}

.spinner {
  position: absolute;
  top: 50%;
  left: 50%;
}
</style>
<template>
  <div class="md-layout md-gutter">
    <div class="md-layout-item">
      <md-field>
        <label>{{label}}</label>
        <md-select v-model="selected">
          <md-option v-for="(item, index) in items" :key="index" :value="item.id">{{item.label}}</md-option>
        </md-select>
      </md-field>
    </div>
  </div>
</template>

<script>
export default {
  name: 'select',
  props: {
    label: {
      type: String,
      default: ''
    },
    items: {
      type: Array,
      default: []
    }
  },
  watch: {
    selected: function() {
      this.$emit('input', this.selected);
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
    .md-select-menu {
        background-image: white;
    }
</style>
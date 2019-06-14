<template>
  <v-data-table
    :headers="headers"
    :items="users"
    select-all
    item-key="id"
    class="elevation-1"
    :loading="loading"
  >
    <template v-slot:headers="props">
      <tr>
        <th>
          <v-checkbox
            :input-value="props.all"
            :indeterminate="props.indeterminate"
            primary
            hide-details
            @change="toggleAll"
          ></v-checkbox>
        </th>
        <th v-for="header in props.headers" :key="header.text">{{ header.text }}</th>
      </tr>
    </template>
    <v-progress-linear v-slot:progress color="blue" indeterminate></v-progress-linear>
    <template v-slot:items="props">
      <tr :active="props.item.selected" @click="props.item.selected = !props.item.selected">
        <td>
          <v-checkbox :input-value="props.item.selected" primary hide-details></v-checkbox>
        </td>
        <td>{{ props.item.id }}</td>
        <td class="text-xs">{{ props.item.login }}</td>
        <td class="text-xs">{{ props.item.name }}</td>
        <td class="text-xs">{{ props.item.status }}</td>
      </tr>
    </template>
    <template v-slot:footer>
      <td :colspan="headers.length + 1">
        <div class="status-change">
          <app-select class="select" v-model="select" label="Status" :items="statusLabels"></app-select>
          <md-button @click="updateStatuses" class="md-raised md-primary">Change</md-button>
        </div>
      </td>
    </template>
  </v-data-table>
</template>

<script>
import api from '../../api';
import AppSelect from '../basic/app-select';

const headers = [
  {
    text: 'Id',
    align: 'left',
    sortable: false,
    value: 'id'
  },
  { text: 'Login', value: 'login' },
  { text: 'Name', value: 'name' },
  { text: 'Status', value: 'status' }
];

const statusLabels = [
  { id: '0', label: 'Pending' },
  { id: '1', label: 'Blocked' },
  { id: '2', label: 'Active' },
  { id: '3', label: 'Admin' }
];

export default {
  components: {
    AppSelect
  },
  name: 'user-management',
  created() {
    this.getUsers();
  },
  methods: {
    toggleAll() {
      if (this.selected.length) {
        this.selected = [];
        this.users.forEach(user => {
          user.selected = false;
        });
      } else {
        this.selected = this.users.slice();
        this.users.forEach(user => {
          user.selected = true;
        });
      }
    },
    updateStatuses() {
      var users = this.selected.length
        ? this.selected.map(x => x.id)
        : this.users.filter(obj => obj.selected).map(x => x.id);
      if (users.length) {
        api.user.post.changeUsersStatus(users, this.select).then(res => {
          this.getUsers();
        });
      }
    },
    getUsers() {
      this.loading = true;
      api.user.get
        .getAll()
        .then(res => {
          this.users = res.data;
          this.users.forEach(user => {
            user.status = this.statusLabels[user.status].label;
            user.selected = false;
          });
        })
        .finally(() => (this.loading = false));
    }
  },
  data() {
    return {
      users: [],
      headers: headers,
      statusLabels: statusLabels,
      selected: [],
      select: '',
      loading: true
    };
  }
};
</script>

<style scoped>
.select {
  width: 20em;
}

.status-change {
  display: flex;
  align-items: center;
}
</style>
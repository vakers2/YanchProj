<template>
    <v-data-table
        :headers="headers"
        :items="users"
        class="elevation-1"
    >
        <template v-slot:items="props">
            <td>{{ props.item.id }}</td>
            <td class="text-xs">{{ props.item.login }}</td>
            <td class="text-xs">{{ props.item.name }}</td>
            <td class="text-xs">{{ props.item.status }}</td>
        </template>
    </v-data-table>
</template>

<script>
import api from '../../api';

const headers = [
    {
        text: 'Id',
        align: 'left',
        sortable: false,
        value: 'id'
    },
    { text: 'Login', value: 'login' },
    { text: 'Name', value: 'name' },
    { text: 'Status', value: 'status'}
]

export default {
  name: 'user-management',
  created() {
      api.user.get.getAll()
        .then(res => {
            this.users = res.data
        })
  },
  data() {
    return {
        users: [],
        headers: headers
    };
  }
};
</script>

<style scoped>
</style>
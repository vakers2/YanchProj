import axios from 'axios'

axios.defaults.baseURL = '/'
axios.defaults.headers.post['Content-Type'] = 'application/json'

export default {
  home: {
    get: {
      getAll () {
        return axios.get('Home/GetAll')
      }
    }
  },
  user: {
    get: {
      getAll () {
        return axios.get('user/getall')
      }
    },
    post: {
      updateUser (firstName, lastName, email, phoneNumber) {
        var data = {
          FirstName: firstName,
          LastName: lastName,
          Email: email,
          PhoneNumber: phoneNumber
        }

        return axios.post('Users/UpdateUserAsync', data)
      },
      deleteUsers (idList) {
        return axios.post('user/delete', idList)
      },
      getAllUsers (data) {
        return axios.post('Users/GetAllUsers', data)
      },
      changeUsersStatus (users, status) {
        var data = {
          userIds: users,
          status
        }
        return axios.post('user/changeUserStatus', data)
      }
    }
  },
  authorization: {
    get: {
      checkUser () {
        return axios.get('Authorization/CheckAuthorization')
      },
      renew (id) {
        return axios.get('Authorization/Renew?id=' + id)
      },
      checkIfAuthorized () {
        return axios.get('user/check')
      }
    },
    post: {
      registerUser (data) {
        return axios.post('user/create', data)
      },
      logInUser (data) {
        return axios.post('user/login', data)
      },
      logInAdmin (email, password) {
        var data = {
          Email: email,
          Password: password
        }

        return axios.post('Authorization/LogInAdmin', data)
      },
      signOut () {
        return axios.post('user/logout')
      }
    }
  },
  post: {
    get: {
      getAll (data) {
        return axios.get('post/getall')
      }
    },
    post: {
      create (title, description) {
        var data = {
          title,
          description
        }

        return axios.post('post/create', data)
      }
    }
  }
}

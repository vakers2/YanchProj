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
      getAllUsers (data) {
        return axios.post('Users/GetAllUsers', data)
      },
      changeUsersStatus (data) {
        return axios.post('Users/ChangeStatus', data)
      }
    }
  },
  authorization: {
    get: {
      checkUser () {
        return axios.get('Authorization/CheckAuthorization')
      },
      signOut () {
        return axios.get('Authorization/SignOutAsync')
      },
      renew (id) {
        return axios.get('Authorization/Renew?id=' + id)
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
      }
    }
  }
}
<template>
  <v-container>
    <v-layout row class="text-xs-center">
      <v-container style="position: relative;top: 13%;" class="text-xs-center">
        <v-card class="login-card" flat>
          <v-card-title primary-title>
            <h4 v-if="isLogin">Login</h4>
            <h4 v-if="!isLogin">Register</h4>
          </v-card-title>
          <v-form ref="form">
            <v-text-field
              v-model="login"
              prepend-icon="person"
              name="Login"
              label="Login"
              :rules="loginRules"
              required
            ></v-text-field>
            <v-text-field
              v-if="!isLogin"
              v-model="name"
              prepend-icon="person"
              name="Name"
              label="Name"
              :rules="nameRules"
              required
            ></v-text-field>
            <v-text-field
              v-model="password"
              prepend-icon="lock"
              name="Password"
              label="Password"
              type="password"
              :rules="passwordRules"
              required
            ></v-text-field>
            <v-card-actions>
              <v-btn
                @click="authorize()"
                class="btn btn-primary text-white"
                large
                block
              >{{LoginLabel}}</v-btn>
            </v-card-actions>
          </v-form>
        </v-card>
      </v-container>
    </v-layout>
  </v-container>
</template>

<script>
import api from '../../api';

const labels = {
  login: 'Log in',
  signup: 'Sign up'
};

const actions = {
  SET_USER_INFO: 'SET_USER_INFO'
};

const rules = {
  LOGIN_MIN: 4,
  NAME_MIN: 4,
  PASSWORD_MIN: 8
};

export default {
  name: 'login',
  computed: {
    LoginLabel: function() {
      return this.isLogin ? labels.login : labels.signup;
    }
  },
  props: {
    isLogin: {
      type: Boolean
    }
  },
  methods: {
    authorize() {
      if (this.validate()) {
        if (!this.isLogin) {
          this.signup();
        } else {
          this.signin();
        }
      }
    },
    signup() {
      var user = {
        Login: this.login,
        Name: this.name,
        Password: this.password
      };
      api.authorization.post.registerUser(user).then(res => {
        this.$store.commit(actions.SET_USER_INFO, res.data);
        this.$router.push('/');
      });
    },
    signin() {
      var user = {
        Login: this.login,
        Password: this.password
      };
      api.authorization.post.logInUser(user).then(res => {
        this.$store.commit(actions.SET_USER_INFO, res.data);
        this.$router.push('/');
      });
    },
    validate() {
      return this.$refs.form.validate();
    }
  },
  data() {
    return {
      login: '',
      name: '',
      password: '',
      allowSpaces: false,
      loginRules: [
        v => !!v || 'Login is required',
        v =>
          (v && v.length >= rules.LOGIN_MIN) ||
          `Login must be at least ${rules.LOGIN_MIN} characters`
      ],
      nameRules: [
        v => !!v || 'Name is required',
        v =>
          (v && v.length >= rules.NAME_MIN) ||
          `Name must be at least ${rules.NAME_MIN} characters`
      ],
      passwordRules: [
        v => !!v || 'Password is required',
        v =>
          (v && v.length >= rules.PASSWORD_MIN) ||
          `Password must be at least ${rules.PASSWORD_MIN} characters`
      ]
    };
  }
};
</script>

<style scoped>
.container {
  width: 500px;
}

.login-card {
  border: solid 1px black;
  padding: 10px;
}

.text-white {
  color: #ffffff;
}
</style>
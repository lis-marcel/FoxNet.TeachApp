<template>
  <div class="container">
    <div class="center">
        <div v-if="loginFailed" class="alert alert-danger" role="error">
            <p>Incorrect login or password</p>
        </div>
      <main class="form-signin">
        <form class="login" @submit.prevent="tryLogin">
          <h1 class="h3 mb-3 fw-normal">Please sign in</h1>
          <div class="form-floating">
            <label for="floatingInput">Login</label>
            <input
              required
              v-model="login"
              type="text"
              class="form-control"
              id="floatingInput"
              placeholder="Login"
            />
          </div>
          <div class="form-floating">
            <label for="floatingPassword">Password</label>
            <input
              required
              v-model="password"
              type="password"
              class="form-control"
              id="floatingPassword"
              placeholder="Password"
            />
          </div>
          <br />
          <button class="w-100 btn btn-lg btn-primary" type="submit">
            Sign in
          </button>
        </form>
      </main>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      login: "",
      password: "",
      loginFailed: false,
    };
  },

  methods: {
    tryLogin: function () {
      this.loginFailed = false;
      
      let login = this.login;
      let password = this.password;

      this.$store
        .dispatch("login", { login, password })
        .then(() => {
            this.loginFailed = false
            this.$router.push("/")
          })
        .catch((error) => console.error(error), (this.loginFailed = true), this.login = '', this.password = '');
    },
  },
};
</script>

<style>
.text-center {
  text-align: center !important;
}

body {
  display: flex;
  align-items: center;
  padding-top: 40px;
  padding-bottom: 40px;
  background-color: #f5f5f5;
  margin: 0;
  font-family: var(--bs-font-sans-serif);
  font-size: 1rem;
  font-weight: 400;
  line-height: 1.5;
  color: #212529;
  background-color: #fff;
  -webkit-text-size-adjust: 100%;
  -webkit-tap-highlight-color: transparent;
}

*,
::after,
::before {
  box-sizing: border-box;
}

.alert alert-danger {
    text-align: center;
}

.container {
  height: 700px;
  width: 900px;
  position: relative;
}

.center {
  width: 50%;
  height: 50%;
  overflow: auto;
  margin: auto;
  position: absolute;
  top: 0; left: 0; bottom: 0; right: 0;
}
</style>
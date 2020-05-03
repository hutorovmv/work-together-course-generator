<template>
  <div class="wrapper">
    <h1>Authentication</h1>
    <form class="form">
      <input type="text" id="userName" v-model="userName" />
      <input type="password" id="password" v-model="password" />
      <button class="form__btn" @click.prevent="authenticateUser()">Authenticate</button>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      userName: '',
      password: ''
    };
  },
  methods: {
    authenticateUser() {
      const user = {
        UserName: this.userName,
        Password: this.password
      };
      this.$http
        .post("https://localhost:44343/api/account/authenticate", user)
        .then(
          function(response) {
            console.log(response);
            this.$router.push({ path: "/home" });
          },
          function(error) {
            console.warn("Error:", error.message);
          }
        );
    }
  }
};
</script>

<style>

</style>
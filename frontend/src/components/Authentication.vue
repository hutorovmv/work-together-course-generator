<template>
  <div id="authentocation">
    <div class="main-wrapper">
      <div class="wrapper city_bg">
        <div class="container">
          <div class="row justify-content-center logo">
            <img src="../assets/logo.png" alt="logo" />
          </div>
          <div class="row justify-content-center">
            <h1 class="authentication__title title">
              Вхід
              <span>до особистого кабінету</span>
            </h1>
          </div>
          <div class="row justify-content-center text-align-center">
            <div class="col-md-4">
              <form class="form authentication__form">
                <div class="form__box">
                  <input type="text" id="userName" v-model="userName" placeholder="Email" />
                </div>
                <div class="form__box">
                  <input type="password" id="password" v-model="password" placeholder="Пароль" />
                </div>
                <div class="form__box flex">
                  <a href="#" class="form__forget-pass">Забули пароль?</a>
                  <button
                    class="button authentication__btn"
                    @click.prevent="authenticateUser()"
                  >Ввійти</button>
                </div>
              </form>
              <div class="new-user">
                Новий користувач?
                <router-link to="/register">Створити обліковий запис</router-link>
              </div>
            </div>
          </div>
        </div>
      </div>
      <footer class="footer">
        <div class="copy">© 2020 practifly.com</div>
        <router-link to="/home" class="about-link">Про нас</router-link>
      </footer>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      userName: "",
      password: ""
    };
  },
  methods: {
    authenticateUser() {
      const user = {
        UserName: this.userName,
        Password: this.password
      };
      this.$http.post("https://localhost:44343/api/authentication", user).then(
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

<style lang="scss">
.authentication__form {
  display: block;
  .form__box {
    width: 100%;
    &.flex {
      display: flex;
      justify-content: space-between;
      align-items: center;
    }
  }
}
.authentication__btn {
  margin-top: 0;
}
.form__forget-pass {
  color: #7367f0;
  font-size: 15px;
}
.new-user {
  margin-top: 30px;
  color: #323232;
  a {
    display: block;
    color: #7367f0;
    margin-top: 10px;
    font-weight: 700;
    font-weight: 700;
  }
}
</style>
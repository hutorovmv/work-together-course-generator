<template>
  <div id="register">
    <div class="wrapper">
      <h1 class="test-block">Registration</h1>
      <form class="form">
        <input type="text" placeholder="Email" id="email" v-model="form.Email" />
        <input type="text" placeholder="Phone" id="phoneNumber" v-model="form.PhoneNumber" />
        <input type="text" placeholder="First Name" id="firstName" v-model="form.FirstName" />
        <input type="text" placeholder="Last Name" id="lastName" v-model="form.LastName" />
        <input type="text" placeholder="Birth Date" id="birthDate" v-model="form.BirthDate" />
        <input type="text" placeholder="Lang Code" id="preferedLangCode" v-model="form.PreferedLangCode" />
        <input type="password" placeholder="Password" id="password" v-model="form.Password" />
        <input type="password" placeholder="Password Confirm" id="passwordConfirm" v-model="form.PasswordConfirm" />
        <button class="form__btn" @click.prevent="postData()">Sign up</button>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      form: {
        Email: "",
        PhoneNumber: "",
        FirstName: "",
        LastName: "",
        BirthDate: "",
        PreferedLangCode: "",
        Password: "",
        PasswordConfirm: ""
      },
      title: "Hello World",
      url: "https://localhost:44343/api/languages",
      resposedData: {}
    };
  },
  methods: {
    getData() {
      // this.$http.get(this.url).then(
      //   function(response) {
      //     console.log(response);
      //   },
      //   function(error) {
      //     console.warn("Error: ", error.message);
      //   }
      // );
    },
    postData() {
      this.$http.post("https://localhost:44343/api/account", this.form).then(
        function() {
          console.log(this.form.Email);
          console.log(this.form.Password);
          this.$router.push({ path: "/auth" });
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
* {
   box-sizing: border-box;
}
.form {
  max-width: 600px;
  width: 100%;
  input {
    display: block;
    border-radius: 5px;
    width: 100%;
    font-size: 16px;
    border-color: rgb(107, 145, 221);
    padding: 15px;
    outline: none;
    color: rgb(107, 145, 221);
    & + input {
      margin-top: 15px;
    }
  }
  button {
    margin-top: 15px;
    display: block;
    width: 100%;
    padding: 15px;
    font-size: 20px;
    color: #fff;
    background: linear-gradient(90deg, rgba(27,54,97,1) 0%, rgba(169,61,218,1) 100%);
    border: none;
    border-radius: 5px;
    cursor: pointer;
  }
}
</style>

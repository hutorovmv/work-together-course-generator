<template>
  <div id="app">
    <h1 class="test-block">{{ title }}</h1>
    <form>
      <input type="text" id="email" v-model="form.Email">
      <input type="text" id="phoneNumber" v-model="form.PhoneNumber">
      <input type="text" id="firstName" v-model="form.FirstName">
      <input type="text" id="lastName" v-model="form.LastName">
      <input type="text" id="lastName" v-model="form.BirthDate">
      <input type="text" id="lastName" v-model="form.PreferedLangCode">
      <input type="text" id="lastName" v-model="form.Password">
      <input type="text" id="lastName" v-model="form.PasswordConfirm">
      <button class="form__btn" @click.prevent="postData()">Sign up</button>
    </form>
  </div>
</template>

<script>
export default {
  name: "App",
  data() {
    return {
      form: {
        Email: 'mykolahutorov@gmail.com',
        PhoneNumber: '380631111111',
        FirstName: 'Mykola',
        LastName: 'Hutorov',
        BirthDate: '2001-02-16T00:00:00.0000000',
        PreferedLangCode: 'eng',
        Password: '12345678',
        PasswordConfirm: '12345678'
      },
      title: "Hello World",
      url: "https://localhost:44343/api/languages",
      resposedData: {}
    };
  },
  methods: {
    getData() {
      this.$http.get(this.url).then(
        function(response) {
          console.log(response);
        },
        function(error) {
          console.warn("Error: ", error.message);
        }
      );
    },
    postData(){
      // console.log(this.form)
      // const test = JSON.stringify(this.form)
      this.$http.post('https://localhost:44343/api/account', this.form).then(
        function(response){
          console.log(response)
        },
        function(error){
          console.warn("Error:", error.message)
        }
      )
    }
  },
  created(){
    this.getData()
  },
  components: {
    // HelloWorld
  },
  mounted(){
    
  }
};

// async function request(url, method = "GET", data = null) {
//   try {
//     const headers = {}
//     let body

//     if (data) {
//       headers['Content-Type'] = 'application/json'
//       body = JSON.stringify(data);
//     }

//     const response = await fetch(url, {
//       method,
//       headers,
//       body
//     });

//     return await response.json();
//   } catch (e) {
//     console.warn("Error:", e.message);
//   }
// }
</script>

<style lang="scss">
#app {
  .test-block {
    color: #000;
  }
}
</style>

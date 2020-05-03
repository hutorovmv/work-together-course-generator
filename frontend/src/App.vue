<template>
  <div id="app">
    <div class="wrapper" v-if="$router.currentRoute.fullPath === '/'">
      <!-- <div class="test" @click="test()">asdfasdf</div> -->
      <router-link to="/register" class="register__link link"  :class="{hide: clicked}">To register</router-link>
    </div>
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  name: "App",
  data() {
    return {
      clicked: false
    }
  },
  // methods: {
  //   test(){
  //     console.log(this.$router.currentRoute.fullPath)
  //   }
  // }
  // methods: {
  //   getData() {
  //     // this.$http.get(this.url).then(
  //     //   function(response) {
  //     //     console.log(response);
  //     //   },
  //     //   function(error) {
  //     //     console.warn("Error: ", error.message);
  //     //   }
  //     // );
  //   },
  //   postData(){
  //     this.$http.post('https://localhost:44343/api/account', this.form).then(
  //       function(response){
  //         console.log(response)
  //       },
  //       function(error){
  //         console.warn("Error:", error.message)
  //       }
  //     )
  //   },
  //   authenticateUser(){
  //     const user = {
  //       UserName: this.form.Email,
  //       Password: this.form.Password
  //     }
  //     this.$http.post('https://localhost:44343/api/account/authenticate', user).then(
  //       function(response){
  //         console.log(response)
  //       },
  //       function(error){
  //         console.warn("Error:", error.message)
  //       }
  //     )
  //   }
  // },
  // created(){
  //   this.getData()
  // },
  // components: {

  // },
  // mounted(){

  // }
};
</script>

<style lang="scss">
.link {
  text-decoration: none;
  color: rgb(107, 145, 221);
  font-size: 25px;
  &.hide{
    display: none;
  }
}
.wrapper {
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  h1 {
    color: rgb(107, 145, 221);
  }
}
</style>

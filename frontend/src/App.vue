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
@import url('https://fonts.googleapis.com/css2?family=Open+Sans:wght@400;700&display=swap');

body{
  font-family: 'Open Sans', sans-serif;
  font-size: 14px !important;
}

.link {
  text-decoration: none;
  // color: #007bff;
  font-size: 25px;
  &.hide{
    display: none;
  }
}
.wrapper {
  // height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  flex-grow: 1;
  // h1 {
  //   color: #007bff;
  // }
}
.main-wrapper{
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}
body a{
  text-decoration: none;
  color: inherit;
  transition: all .3s;
  &:hover{
    color: #7367f0;
  }
}
</style>

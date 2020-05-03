import Vue from 'vue'
import VueResource from 'vue-resource'
import VueRouter from 'vue-router'
import Register from './components/Registration.vue'
import Auth from './components/Authentication.vue'
import Home from './components/Home.vue'
import App from './App.vue'

Vue.config.productionTip = false

Vue.use(VueResource)
Vue.use(VueRouter)

const routes = [
  { path: '/register', component: Register },
  { path: '/auth', component: Auth },
  { path: '/home', component: Home },
]

const router = new VueRouter({
  routes
})

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')



// export default new VueRouter({
//   routes: [
//     {
//       path: '/register',
//       name: 'registration',
//       component: Register
//     }
//   ]
// })
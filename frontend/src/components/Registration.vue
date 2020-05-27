<template>
  <div id="register">
    <div class="main-wrapper">
      <div class="wrapper city_bg">
        <div class="container">
          <div class="row justify-content-center logo">
            <img src="../assets/logo.png" alt="logo" />
          </div>
          <div class="row justify-content-center">
            <h1 class="registration__title title">Реєстрація користувача</h1>
          </div>
          <div class="row justify-content-center">
            <div class="col-md-8">
              <form class="registration__form form">
                <div class="form__box">
                  <label for="firstName">Ім’я</label>
                  <input type="text" placeholder="Ім’я" id="firstName" v-model="form.FirstName" />
                </div>

                <div class="form__box">
                  <label for="lastName">Прізвище</label>
                  <input type="text" placeholder="Прізвище" id="lastName" v-model="form.LastName" />
                </div>

                <div class="form__box">
                  <label for="email">Email</label>
                  <input type="text" placeholder="Email" id="email" v-model="form.Email" />
                </div>

                <div class="form__box">
                  <label for="phoneNumber">Телефон</label>
                  <input
                    type="text"
                    placeholder="Телефон"
                    id="phoneNumber"
                    v-model="form.PhoneNumber"
                  />
                </div>
                <div class="form__box">
                  <label for="birthDate">Дата народження</label>
                  <div class="form__box-inner" id="birthDate">
                    <input type="text" placeholder="28" id="birthDay" v-model="birthDate.day" />
                    <div class="drop-wrap">
                      <div class="birthDate drop-btn month" @click="dropOpen">Лютого</div>
                      <ul class="drop-menu month">
                        <li
                          class="month"
                          @click="changeMonth"
                          v-for="month in months"
                          :key="month.id"
                        >
                          {{ month.name }}
                          <span>{{ month.number }}</span>
                        </li>
                      </ul>
                    </div>
                    <input type="text" placeholder="1995" id="birthYear" v-model="birthDate.year" />
                  </div>
                </div>

                <div class="form__box">
                  <label for="preferedLangCode">Виберіть мову</label>
                  <div class="drop-wrap">
                    <div class="preferedLangCode drop-btn lang" @click="dropOpen">Виберіть мову</div>
                    <ul class="drop-menu lang">
                      <li
                        class="language"
                        @click="changeLang"
                        v-for="language in languages"
                        :key="language.code"
                      >
                        {{ language.name }}
                        <span>{{ language.code }}</span>
                      </li>
                    </ul>
                  </div>
                </div>

                <div class="form__box">
                  <label for="password">Пароль</label>
                  <input type="password" placeholder="Пароль" id="password" v-model="form.Password" />
                </div>

                <div class="form__box">
                  <label for="passwordConfirm">Підтвердження пароля</label>
                  <input
                    type="password"
                    placeholder="Підтвердження пароля"
                    id="passwordConfirm"
                    v-model="form.PasswordConfirm"
                  />
                </div>

                <button class="button registration__btn" @click.prevent="postData">Зареєструватися</button>
              </form>
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
      birthDate: {
        day: "",
        month: "",
        year: ""
      },
      title: "Hello World",
      url: "https://localhost:44343/api/languages",
      resposedData: {},
      languages: [],
      months: [
        { id: 1, name: "Січня", number: "01" },
        { id: 2, name: "Лютого", number: "02" },
        { id: 3, name: "Березня", number: "03" },
        { id: 4, name: "Квітня", number: "04" },
        { id: 5, name: "Травня", number: "05" },
        { id: 6, name: "Червня", number: "06" },
        { id: 7, name: "Липня", number: "07" },
        { id: 8, name: "Серпня", number: "08" },
        { id: 9, name: "Вересня", number: "09" },
        { id: 10, name: "Жовтня", number: "10" },
        { id: 11, name: "Листопада", number: "11" },
        { id: 12, name: "Грудня", number: "12" }
      ]
    };
  },
  mounted() {
    this.$http.get(this.url).then(
      function(response) {
        console.log(response);
        this.languages = response.body;
      },
      function(error) {
        console.warn("Error: ", error.message);
      }
    );
  },
  methods: {
    postData() {
      this.form.BirthDate = `${this.birthDate.year}-${this.birthDate.month}-${this.birthDate.day}T00:00:00.0000000`;

      console.log(this.form);
      this.$http.post("https://localhost:44343/api/users", this.form).then(
        function() {
          console.log(this.form.Email);
          console.log(this.form.Password);

          this.$router.push({ path: "/auth" });
        },
        function(error) {
          console.warn("Error:", error.message);
        }
      );
    },
    dropOpen(event) {
      event.target.classList.toggle("active");
      event.target.nextSibling.classList.toggle("show");
    },
    changeLang(event) {
      document.querySelector(".drop-btn.lang").classList.remove("active");
      document.querySelector(".drop-menu.lang").classList.remove("show");
      if (event.target.classList.contains("active")) {
        return false;
      }
      let languages = document.querySelectorAll(".language");
      for (let i = 0; i < languages.length; i++) {
        if (languages[i] === event.target) {
          event.target.classList.add("active");
        } else {
          languages[i].classList.remove("active");
        }
      }
      document.querySelector(
        ".preferedLangCode"
      ).innerHTML = document.querySelector(".language.active").innerHTML;
      this.form.PreferedLangCode = document.querySelector(
        ".language.active span"
      ).innerHTML;
    },
    changeMonth(event) {
      document.querySelector(".drop-btn.month").classList.remove("active");
      document.querySelector(".drop-menu.month").classList.remove("show");
      if (event.target.classList.contains("active")) {
        return false;
      }
      let months = document.querySelectorAll(".month");
      for (let i = 0; i < months.length; i++) {
        if (months[i] === event.target) {
          event.target.classList.add("active");
        } else {
          months[i].classList.remove("active");
        }
      }
      document.querySelector(".birthDate").innerHTML = document.querySelector(
        ".month.active"
      ).innerHTML;
      this.birthDate.month = document.querySelector(
        ".month.active span"
      ).innerHTML;
    }
  }
};
</script>

<style lang="scss">
* {
  box-sizing: border-box;
}

.city_bg {
  background-image: url(../assets/register_bg.png);
  background-repeat: no-repeat;
  background-position: center bottom;
}

.title {
  margin-bottom: 25px;
  color: #22222a;
  font-weight: 700;
  font-size: 24px;
  text-align: center;
}
.authentication__title{
  font-size: 20px;
  span {
    display: block;
    font-size: 24px;
    font-weight: 400;
    margin-top: 10px;
  }
}
.text-align-center {
  text-align: center;
}
.logo {
  margin-bottom: 70px;
}
.form {
  display: flex;
  flex-wrap: wrap;
  border-radius: 5px;
  border: 1px solid #ebeafc;
  background-color: #ffffff;
  padding: 20px;
  padding-bottom: 30px;
  .form__box {
    width: 50%;
    padding: 10px;
    label {
      font-size: 14px;
    }
    input {
      display: block;
      border-radius: 5px;
      background-color: #f3f6f9;
      border: none;
      width: 100%;
      padding: 12px 15px;
      outline: none;
      transition: all 0.3s;
      box-shadow: 0 0 3px rgba(#000, 0);
      &:focus {
        box-shadow: 0 0 3px rgba(#000, 0.4);
      }
      &::placeholder {
        font-size: 14px;
      }
    }
  }
}
.button {
  border-radius: 5px;
  border: none;
  background-color: #7367f0;
  font-size: 14px;
  font-weight: 700;
  color: #fff;
  padding: 8px 20px;
  transition: all 0.3s;
  border: 1px solid transparent;
  &:hover {
    background-color: #fff;
    color: #7367f0;
    border: 1px solid #7367f0;
  }
}
.registration__btn,
.authentication__btn {
  margin-left: auto;
  margin-right: 10px;
  margin-top: 10px;
}
.drop-btn {
  border-radius: 5px;
  background-color: #f3f6f9;
  width: 100%;
  padding: 12px 15px;
  padding-right: 30px;
  cursor: pointer;
  user-select: none;
  position: relative;
  &::after {
    content: "";
    position: absolute;
    background-image: url(../assets/angle-down.svg);
    background-repeat: no-repeat;
    background-position: center;
    background-size: contain;
    width: 10px;
    height: 6px;
    right: 10px;
    top: 50%;
    transform: translateY(-50%);
    transition: all 0.3s;
  }
  &.active {
    &::after {
      transform: translateY(-50%) rotate(180deg);
    }
  }
}
.form__box-inner {
  display: flex;
  .drop-wrap {
    margin: 0 10px;
    width: 150px;
    flex-shrink: 0;
  }
}
.drop-wrap {
  position: relative;
  span {
    display: none;
  }
  .drop-menu {
    position: absolute;
    left: 0;
    top: 100%;
    width: 100%;
    list-style: none;
    padding-left: 0;
    border-radius: 5px;
    border: 1px solid #ebeafc;
    background-color: #ffffff;
    padding: 20px 10px;
    opacity: 0;
    transition: all 0.3s;
    visibility: hidden;
    pointer-events: none;
    &.month {
      display: flex;
      flex-wrap: wrap;
      width: auto;
      min-width: 300px;
      left: 50%;
      transform: translateX(-50%);
      li {
        width: 33.333%;
      }
    }
    &.show {
      opacity: 1;
      visibility: visible;
      pointer-events: all;
    }
    li {
      padding: 10px;
      border-radius: 5px;
      transition: all 0.3s;
      &:hover {
        background-color: rgba(#7367f0, 0.5);
      }
      cursor: pointer;
      &.active {
        background-color: #7367f0;
        color: #fff;
      }
    }
  }
}
.footer {
  padding: 19px 0 15px;
  background-color: #27274b;
  text-align: center;
  position: relative;
  color: #b7b5cb;
  font-size: 15px;
  .about-link {
    position: absolute;
    top: 50%;
    transform: translateY(-50%);
    right: 20%;
  }
}
</style>

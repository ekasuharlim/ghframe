<script setup lang="ts">
import { ref } from 'vue'
import { useAuthenticationStore } from '@/stores/authentication'
import { Result } from '@/primitives/Result'
import { useRouter } from 'vue-router'

const authStore = useAuthenticationStore()
const router = useRouter()

const email = ref<string>('')
const password = ref<string>('')

async function login(): void {
  const result: Result = await authStore.login(email.value, password.value)

  if (result.isSuccess) {
    return router.replace({ name: 'home' })
  }

  alert(result.error)
}
</script>

<template>
  <v-container fluid class="fill-height pa-0">
    <v-row no-gutters class="h-100">

      <!-- LEFT PANEL -->
      <v-col
        cols="12"
        md="6"
        class="d-flex flex-column justify-center align-center px-10 py-10"
        style="background-color: #121212; color: white;"
      >
        <v-img
          src="https://cdn.vuetifyjs.com/images/logos/v.png"
          contain
          width="40"
          class="mb-6"
        />

        <div class="text-h4 font-weight-bold mb-1">Welcome back!</div>
        <div class="text-subtitle-1 mb-8">Log into your account</div>

        <v-form @submit.prevent="login" style="width: 100%; max-width: 350px">
          <v-text-field
            v-model="email"
            label="Email"
            type="email"
            density="comfortable"
            prepend-inner-icon="mdi-email-outline"
            class="mb-4"
            color="blue"
            variant="outlined"
            hide-details
          />

          <v-text-field
            v-model="password"
            label="Password"
            :type="showPassword ? 'text' : 'password'"
            :append-inner-icon="showPassword ? 'mdi-eye' : 'mdi-eye-off'"
            @click:append-inner="showPassword = !showPassword"
            density="comfortable"
            prepend-inner-icon="mdi-lock-outline"
            class="mb-2"
            color="blue"
            variant="outlined"
            hide-details
          />

          <div class="text-right text-caption mb-4">
            <a href="#" class="text-blue">Forgot password?</a>
          </div>

          <v-btn type="submit" color="blue" size="large" block class="mb-6">
            Log In
          </v-btn>

          <div class="text-subtitle-2 text-center mb-4">
            <span class="text-grey">Or continue with</span>
          </div>

          <v-row justify="center" class="mb-6">
            <v-btn icon class="mx-2" variant="outlined" color="red">
              <v-icon>mdi-google</v-icon>
            </v-btn>
            <v-btn icon class="mx-2" variant="outlined" color="blue-darken-4">
              <v-icon>mdi-facebook</v-icon>
            </v-btn>
            <v-btn icon class="mx-2" variant="outlined" color="grey-darken-3">
              <v-icon>mdi-github</v-icon>
            </v-btn>
          </v-row>

          <div class="text-caption text-center">
            Don't have an account? <a href="#" class="text-blue">Sign up</a>
          </div>
        </v-form>
      </v-col>

      <!-- RIGHT PANEL -->
      <v-col cols="12" md="6" class="hidden-sm-and-down">
        <v-img
          src="@/assets/login-image.jpg"
          cover
          height="100%"
          width="100%"
          class="rounded-0"
        />
      </v-col>

    </v-row>
  </v-container>
</template>


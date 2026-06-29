<script lang="ts">
    import Container from "./Container.svelte";
    import { Turnstile } from "svelte-turnstile";
</script>

<Container>
    <form method="post">
        <label>
            Username
            <input name="username" type="text" required />
        </label>
        <label>
            Email 
            <input name="email" type="email" required />
        </label>
        <label>
            Text
            <textarea name="text" class="h-[200px] reseze-none" required></textarea>
        </label>
        <div class="flex justify-center p-4">
            <Turnstile siteKey="0x4AAAAAADr8Hcb17gPctx9g" />
        </div>
        <button>Send</button>
    </form>
</Container>

<style>
    form { display: grid}
    label { display: grid }
</style>

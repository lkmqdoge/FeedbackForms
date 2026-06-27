<script lang="ts">
    import Container from "./Container.svelte";
    import { Turnstile } from "svelte-turnstile";
</script>

<Container>
    <form>
        <label>
            Username
            <input type="text" />
        </label>
        <label>
            Email 
            <input type="email" />
        </label>
        <label>
            Text
            <textarea name="text" class="h-[200px] resize-none"></textarea>
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

<script lang="ts">
    import Container from "$lib/Container.svelte";
</script>

<Container>
    <h1>Login</h1>
    <form method="post">
        <label>
            Email
            <input name="email" type="email">
        </label>
        <label>
            password
            <input name="password" type="password">
        </label>
        <button>Login</button>
    </form>
</Container>

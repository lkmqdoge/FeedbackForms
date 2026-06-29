<script lang="ts">
    import Container from "$lib/Container.svelte";
</script>

<Container>
    <h1>Register</h1>
    <form method="post">
        <label>
            UserName
            <input name="username" type="text">
        </label>
        <label>
            Email
            <input name="email" type="email">
        </label>
        <label>
            password
            <input name="password" type="password">
        </label>
        <button>Register</button>
    </form>
</Container>

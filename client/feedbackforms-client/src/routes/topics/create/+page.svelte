<script lang="ts">
    import Container from "$lib/Container.svelte";
</script>

<Container>
    <h1>Create a new form</h1>
    <form method="post">
        <label>
            Title
            <input name="title" type="text">
        </label>
        <label>
            Description
            <textarea name="description" class="h-[200px] resize-none"></textarea>
        </label>
        <button>Publish</button>
    </form>
</Container>

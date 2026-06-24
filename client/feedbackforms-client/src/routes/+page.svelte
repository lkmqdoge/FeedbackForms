<script>
    import AnswerForm from "$lib/AnswerForm.svelte";
    import BorderContainer from "$lib/BorderContainer.svelte";
    import Topic from "$lib/Topic.svelte";
</script>

<div class="grid-cols-2 grid gap-4">
    <BorderContainer>
        <AnswerForm />
    </BorderContainer>
    <BorderContainer>
        <Topic title="Test" bodyText="WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWwwwWWWWWWW" />
    </BorderContainer>
</div>

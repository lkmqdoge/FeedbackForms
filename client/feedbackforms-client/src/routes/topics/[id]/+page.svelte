<script lang="ts">
    import Answer from "$lib/Answer.svelte";
    import AnswerForm from "$lib/AnswerForm.svelte";
    import Topic from "$lib/Topic.svelte";
    import type { PageProps } from "./$types";

    let { data }: PageProps = $props();
    let copied =  $state(false);

    async function copyCurrentUrl() {
        if (typeof window !== "undefined") {
            try {
                const currentUrl = window.location.href;
                await navigator.clipboard.writeText(currentUrl);
                copied = true;
                setTimeout(() => copied = false, 2000); 
            } catch (err) {
                console.error("Failed to copy URL: ", err);
            }
        }
    }
</script>

<div class="flex flex-col gap-4">
    <Topic
        title={data.topic.title ?? ""}
        bodyText={data.topic.body ?? ""}
    />
    {#if data.answers}
        <h1>Answers: {data.answers.length}</h1>
        <button onclick={copyCurrentUrl}>
            {copied ? "Copied!" : "Copy link"}
        </button>
        {#each data.answers as answer }
           <Answer
                userName={answer.userName}
                email={answer.email}
                text={answer.text}
            />
        {/each}
    {:else}
        <AnswerForm />
    {/if}
</div>



<script lang="ts">
    import TopicPreview from "$lib/TopicPreview.svelte";
    import type { PageProps } from "./$types";

    let { data }: PageProps = $props();
</script>
<h1>{data.user.userName}</h1>
<h1>{data.user.email}</h1>
<h1>{data.user.id}</h1>

{#each data.topics as topic }
    <TopicPreview
        title={topic.title}
        bodyText={topic.body}
        topicId={topic.id}
    />
{/each}

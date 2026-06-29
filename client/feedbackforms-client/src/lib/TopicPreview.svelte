<script lang="ts">
    import Container from "./Container.svelte";

    interface Props {
        title?: string | null;
        bodyText?: string | null;
        topicId?: string;
    }
    let { title, bodyText, topicId }: Props = $props();
</script>

<Container>
    <div class="flex justify-between w-full">
        <div class="h-5/6">
            <div class="wrap-anywhere">
                <h1>{title}</h1>
            </div>
            <div class="wrap-anywhere">
                <p class="line-clamp-1">{bodyText}</p>
            </div>
        </div>
        <a
            class="inline-block bg-accennt p-1 text-center rounded-sm" 
            href={`/topics/${topicId}`}
        >Open</a>
    </div>
</Container>

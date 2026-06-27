<script lang="ts">
    import Container from "./Container.svelte";

    interface Props {
        title: string;
        bodyText: string;
    }
    let { title, bodyText }: Props = $props();
</script>

<Container>
    <div class="h-5/6">
        <div class="wrap-anywhere">
            <h1>{title}</h1>
        </div>
        <div class="flex-1 overflow-y-auto overflow-x-hidden wrap-break-words min-h-0">
            <p class="whitespace-pre-wrap">{bodyText}</p>
        </div>
    </div>
</Container>

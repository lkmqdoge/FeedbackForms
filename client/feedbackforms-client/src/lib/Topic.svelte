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
        <hr class="border-t border-s-accennt my-4" />
        <div class="wrap-break-word">
            <p class="whitespace-pre-wrap">{bodyText}</p>
        </div>
    </div>
</Container>

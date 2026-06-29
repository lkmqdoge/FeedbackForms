<script lang="ts">
    import Container from "./Container.svelte";

    interface Props {
        email?: string | null,
        userName?: string | null,
        text?: string | null,
    }
    let { email, userName, text }: Props = $props();
</script>

<Container>
    <div class="h-5/6">
        <div class="wrap-anywhere">
            <h1>{userName}</h1>
        </div>
        <div class="wrap-anywhere">
            <h1>{email}</h1>
        </div>
        <hr class="border-t border-s-accennt my-4" />
        <div class="wrap-break-word">
            <p class="whitespace-pre-wrap">{text}</p>
        </div>
    </div>
</Container>

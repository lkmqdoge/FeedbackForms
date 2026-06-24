<script lang="ts">
    interface Props {
        title: string;
        bodyText: string;
    }
    let { title, bodyText }: Props = $props();
</script>

<div class="wrap-anywhere">
    <h1>{title}</h1>
    <p>{bodyText}</p>
</div>

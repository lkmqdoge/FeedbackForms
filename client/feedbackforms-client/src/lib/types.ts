interface createTopicRequest {
    title: string,
    body: string,
}

interface Topic {
    guid: string,
    title: string,
    body: string,
}

interface Answer {
    topicId: string,
    username: string,
    email: string,
    text: string,
}

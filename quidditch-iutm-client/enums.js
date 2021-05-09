const MATCH_STATUS = {
    SCHEDULED: 0,
    IN_PROGRESS: 1,
    FINISHED: 2
}

const GOLDEN_SNITCH = {
    NONE: 0,
    HOME: 1,
    VISITOR: 2
}

const EVENT_TYPE = {
    GOAL: 0,
    GOLDEN_SNITCH: 1,
    INJURY: 2,
    FAULT: 3
}

module.exports = {
    MATCH_STATUS,
    GOLDEN_SNITCH,
    EVENT_TYPE
}
